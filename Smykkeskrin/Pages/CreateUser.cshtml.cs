using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Smykkeskrin.model;
using Smykkeskrin.Service;

namespace Smykkeskrin.Pages;

public class CreateUser : PageModel
{
    private readonly UserService  _userService;

    public CreateUser(UserService userService)
    {
        _userService = userService;
    }
    
    [BindProperty]
    public User NewUser { get; set; }
    public string? ErrorMessage { get; set; }
    
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        NewUser.UserRole = model.User.Role.User;
        
        if (!ModelState.IsValid)
        {
            return Page(); 
        }

        try
        {
            _userService.CreateUser(NewUser);
            return RedirectToPage("./Login");
        }
        catch(Exception ex)
        {
            ErrorMessage = ex.Message;
            return Page();
        }
        
    }
    
    
    
}