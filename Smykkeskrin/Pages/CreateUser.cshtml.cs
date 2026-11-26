using Microsoft.AspNetCore.Mvc.RazorPages;
using Smykkeskrin.Service;

namespace Smykkeskrin.Pages;

public class CreateUser : PageModel
{
    private readonly UserService  _userService;

    public CreateUser(UserService userService)
    {
        _userService = userService;
    }
    
    public void OnGet()
    {
        
    }
    
    
    
}