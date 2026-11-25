using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Smykkeskrin.model;
using Smykkeskrin.Service;

namespace Smykkeskrin.Pages;

public class Login : PageModel
{
    
    private readonly UserService  _userService;
    
    public Login(UserService userService)
    {
        _userService = userService;
    }
    
    [BindProperty]
    public string Username { get; set; }
    [BindProperty]
    public string Password { get; set; }
    public string ErrorMessage { get; set; }
    
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        User? loggedInUser = _userService.Login(Username, Password);
        if (loggedInUser == null)
        {
            ErrorMessage = "Forkert brugernavn eller adgangskode.";
            return Page();
        }
        HttpContext.Session.SetInt32("UserId", loggedInUser.Id);
        HttpContext.Session.SetString("Username", loggedInUser.Username);
        HttpContext.Session.SetString("UserRole", loggedInUser.UserRole.ToString());

        return RedirectToPage("/Index");
    }
    
    
}