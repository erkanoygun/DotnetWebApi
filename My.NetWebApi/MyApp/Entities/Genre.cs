using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {get; set;}
        public string name { get; set; } = null!;
        public bool isActive { get; set; } = true;
    }
}