using System;
using System.ComponentModel.DataAnnotations;
using Smykkeskrin.model;

namespace Smykkeskrin.model
{
    public class Feed
    {
        public int postId { get; set; } //Feed og post er det samme, uheldig naming convention der ikke kunne rettes i DB
        public string Description { get; set; } //Må ikke være tom, skal udfyldes og det står også i databasen
        public DateTime CreatedOn { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;


        public string FormattedCreatedOn => CreatedOn.ToString("d. MMMM yyyy, kl. HH:mm");
        /* 
        * Vi formatterer tiden så det står pænt på siden
        * databasen henter stadig præcis dato og tid
        */

    }
}
