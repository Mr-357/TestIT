using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TestIT.Models;

namespace TestIT.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Email polje mora biti popunjeno")]
            [EmailAddress(ErrorMessage = "Email nije validan")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Polje za šifru mora biti popunjeno")]
            [StringLength(100, ErrorMessage = "Šifra mora biti najmanje {2} a najviše {1} karaktera duga.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Šifra")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Potvrdite šifru")]
            [Compare("Password", ErrorMessage = "Šifre se ne poklapaju.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Polje za korisnicko ime mora biti popunjeno")]
            [Display(Name = "Korisnicko ime")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Polje za ime mora biti popunjeno")]
            [Display(Name = "Ime")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Polje za prezime mora biti popunjeno")]
            [Display(Name = "Prezime")]
            public string Surname { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.UserName, Email = Input.Email, Name = Input.Name, Surname = Input.Surname };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    await _userManager.AddToRoleAsync(user, "Student");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    if(error.Description == "User name '"+ Input.UserName +"' is already taken.")
                        ModelState.AddModelError(string.Empty, "Korisnicko ime '"+ Input.UserName +"' vec postoji");
                    else if(error.Description == "Email '"+ Input.Email +"' is already taken.")
                        ModelState.AddModelError(string.Empty, "Email '"+ Input.Email +"' vec postoji");
                    else
                        ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
