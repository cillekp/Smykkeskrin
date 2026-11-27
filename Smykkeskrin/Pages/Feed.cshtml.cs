using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Smykkeskrin.model;
using Smykkeskrin.Services;
using System.Collections.Generic;

namespace Smykkeskrin.Pages
{
    public class FeedModel : PageModel
    {
        private readonly FeedService _feedService;

        // Dependency Injection så vi får service, inden siden loades
        public FeedModel(FeedService feedService)
        {
            _feedService = feedService;
        }

        //Lokal liste med alle opslag som HTML kan løbe igennem
        public IEnumerable<Feed> Feeds { get; set; } = new List<Feed>();

        // Data fra en HTML-formular automatisk bliver sendt med ind her
        [BindProperty]
        public string ? NewDescription { get; set; }

        // Denne metode kører, når siden indlæses (HTTP GET)
        public void OnGet()
        {
            Feeds = _feedService.GetAllFeeds();
        }

        // Denne metode kører, når brugeren trykker "Opret opslag" på siden (HTTP POST)
        public IActionResult OnPost()
        {
            // Validering: Tjek om feltet er tomt
            if (string.IsNullOrWhiteSpace(NewDescription))
            {
                ModelState.AddModelError("NewDescription", "Beskrivelsen må ikke være tom.");
                Feeds = _feedService.GetAllFeeds(); // Sørg for at loade feed igen, hvis siden genindlæses ved fejl
                return Page();
            }

            // Hårdkodet brugerId (1) for nu, indtil I får styr på login/Session
            int currentUserId = 9;

            // Opret opslaget via servicen
            _feedService.CreateFeed(NewDescription, currentUserId);

            // Redirect til samme side (så man undgår "form resubmission" hvis brugeren opdaterer siden)
            return RedirectToPage();
        }
    }
}