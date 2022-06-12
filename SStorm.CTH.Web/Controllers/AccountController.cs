using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using SStorm.CTH.Web.Infrastructure;
using SStorm.CTH.Web.Models;

namespace SStorm.CTH.Web.Controllers
{

    public class AccountController : SmartController
    {
        private readonly IUserService _userService;
        private readonly IMailService _mailService;

        public AccountController(IUserService userService, IMailService mailService, IClientNotification notifier) : base(notifier)
        {
            this._userService = userService;
            this._mailService = mailService;

        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel ssn)
        {
            var user = await _userService.GetAllowedUser(ssn.Username, ssn.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View();
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, user.FullName));

            foreach (var role in user.Permissions)
            {
                //identity.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("MainCancerType", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        #region PasswordRecovery
        public static CTHUserEntity GetUserDetailsByEmail(string email)
        {
            var coll = new EntityCollection<DAL.EntityClasses.CTHUserEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(CTHUserFields.Email % email.Trim());
            BL.DataBaseClassHelper.FillCollection(coll, filter, 1, null, null, 0, 0, CTHUserFields.ID, CTHUserFields.UserName, CTHUserFields.Email, CTHUserFields.Password);
            return coll.FirstOrDefault();

        }
        [HttpGet]
        public ActionResult PasswordRecovery()
        {
            return View(new ForgotPasswordModel());
        }
        [HttpPost]
        public ActionResult PasswordRecovery(ForgotPasswordModel model)
        {
            var user = GetUserDetailsByEmail(model.Email);
            if (user != null)
            {
                var decryptedPass = Helper.TextEncryption.Decrypt(user.Password);
                string EmailBody =
                    $@"<strong>Dear {user.UserName} ,</strong>                 
                   <p>Please find your login details for CTH Website. </p>                 
                   <p>We recommend that you change your password on first login into the Website.</p>
                   <strong>Login name :</strong>{user.UserName}<br/>
                   <strong>Password :</strong> {decryptedPass} <br/>
                   Regards,
                   ";
                string title = "CTH Password Recovery";
                string to = user.Email;
                this._mailService.SendEmail(to, " " + title + " ", EmailBody);
                AddSweetNotification("Done", " success!", Helper.NotificationHelper.NotificationType.success);
                return RedirectToAction("Login", "Account");
            }
            else
            {
                AddSweetNotification("Error", " Email Address Not Found!", Helper.NotificationHelper.NotificationType.error);
                return View(model);
            }
        }
        #endregion

    }
}