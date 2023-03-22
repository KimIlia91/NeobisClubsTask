using System.ComponentModel.DataAnnotations;


namespace NeobisTask.Models
{
    public class Account
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        [Range(0, int.MaxValue)]
        public decimal Balance { get; set; }
    }
}
