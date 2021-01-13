using System.ComponentModel.DataAnnotations;

namespace Infestation.Models
{
    public class Human
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public bool IsSick { get; set; }

        [Required]
        public Gender Gender { get; set; }


        [Required]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }

    public enum Gender 
    {
        Undefined,
        Male,
        Female
    }
}