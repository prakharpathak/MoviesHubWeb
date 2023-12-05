using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoviesHubWeb.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [DisplayName("Rating")]
        [Range(0,1000)]
        public int Rating { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;  
    }
}
