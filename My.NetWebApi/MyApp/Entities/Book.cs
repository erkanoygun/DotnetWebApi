using System.ComponentModel.DataAnnotations.Schema;
using MyApp.Entities;

namespace MyApp;

public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int GenereId {get; set;}
    public Genre Genre {get; set;} = null!;
    public int PageCount {get; set;}
    public DateTime PublisDate {get; set;}

}