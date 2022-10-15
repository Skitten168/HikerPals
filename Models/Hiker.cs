using System.ComponentModel.DataAnnotations;

namespace HikerPals.Models
{
    public class Hiker
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string TrailName { get; set; }

        [Required(ErrorMessage = "Please enter your age.")]
        [Range(1, 120, ErrorMessage = "Please enter an age between 1 and 120.")]
        public int Age { get; set; }

        public int AverageDailyMiles { get; set; }

        public int YearsExperience { get; set; }
    }
}
