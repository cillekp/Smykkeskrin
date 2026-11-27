using Microsoft.AspNetCore.Mvc.RazorPages;
using Smykkeskrin.Service;
using Smykkeskrin.model;
using Smykkeskrin.Model;

namespace Smykkeskrin.Pages;

public class CatalogJewlery : PageModel
{
    private readonly JewleryService _jewleryService;

    public CatalogJewlery(JewleryService jewleryservice)
    {
        _jewleryService = jewleryservice;
    }

    public List<Jewlery> Jewleries { get; set; } = new();
    
    public void OnGet()
    {
        Jewleries = _jewleryService.GetAllJewleries();
    }
}