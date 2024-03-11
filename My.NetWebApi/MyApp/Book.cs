using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp;

public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int GenereId {get; set;}
    public int PageCount {get; set;}
    public DateTime PublisDate {get; set;}


}