using System.ComponentModel.DataAnnotations;

namespace Smykkeskrin.Model
{
    public class Feed
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
