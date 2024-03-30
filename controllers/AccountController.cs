
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebData.Models;
using WebData.Models.Account;
using WebData.Models.ViewModel;


namespace WebData.Controllers
{

    public class AccountController : Controller
    {
        private readonly studentDbContext context;
        private readonly IDNTCaptchaValidatorService validatorService;
        public AccountController(studentDbContext context ,IDNTCaptchaValidatorService validatorService)
        {
           
            this.context = context;
            this.validatorService = validatorService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = new User()
                {
                    Id = model.Id,
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    Mobile = model.Mobile,
                    IsActive = model.IsActive,
                    IsRemember = model.IsRemember,

                };
                context.userlogin.Add(data);
                context.SaveChanges();
                TempData["errorMessage"] = "Open Account Succesfully";
                return RedirectToAction("LogIn");


            }
            else
            {

                return View(model);
            }
        }
        [AcceptVerbs("Post", "Get")]
        public IActionResult UsernameExist(string Username)
        {
            var data = context.userlogin.Where(e => e.Username == Username).SingleOrDefault();
            if (data != null)
            {
                return Json($"{Username} alreday in Uses!");
            }
            else
            {
                return Json(true);

            }

        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        //[ValidateDNTCaptcha(ErrorMessage ="Please enter  above code!", CaptchaGeneratorLanguage = Language.English,CaptchaGeneratorDisplayMode =DisplayMode.ShowDigits)]
        public IActionResult LogIn(LogInSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ( !validatorService.HasRequestValidCaptchaEntry())
                {
                    TempData["captchaError"] = "Please enter valid key";
                    return View(model);
                }
                
                var data = context.userlogin.Where(e => e.Username == model.Username).SingleOrDefault();
                if (data != null)
                {
                    bool isValid = (data.Username == model.Username && data.Password == model.Password);
                    if (isValid)
                    {

                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Username) },
                        CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Username", model.Username);

                        return RedirectToAction("Index", "student");
                    }
                    else
                    {
                        TempData["errorMessage"] = "Invalid Password";
                        return View(model);
                    }

                }
                else
                {
                    TempData["errorMessage"] = "Invalid User";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }

        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LogIn", "Account");
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

        
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword( PasswordChangeViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View ();
        }
       
       


    }

    }

   