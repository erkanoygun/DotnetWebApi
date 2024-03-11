using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApp.BookOperations.CreateBook;
using MyApp.BookOperations.GetBooks;
using MyApp.BookOperations.GetBooksById;
using MyApp.BookOperations.UpdateBookCommand;
using MyApp.DBOperation;
namespace MyApp.Controllers;

[ApiController]
[Route("[controller]s")]
public class BookController : ControllerBase
{
    private readonly BookStoreDBContext _context;
    private readonly IMapper _mapper;

    public BookController(BookStoreDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        GetBooksQuery booksQuery = new GetBooksQuery(_context,_mapper);
        var result = booksQuery.Handle();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {

        GetBookByIdQuery bookByIdQuery = new GetBookByIdQuery(_context, _mapper)
        {
            bookId = id
        };
        try
        {
            var result = bookByIdQuery.Handle();
            return Ok(result);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookModel newBook)
    {
        CreateBookCommand command = new CreateBookCommand(_context, _mapper);
        try
        {
            command.Model = newBook;
            command.Handle();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        _context.SaveChanges();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
    {

        UpdateBookCommand updateBookCmd = new UpdateBookCommand(_context)
        {
            bookId = id,
            updateModel = updateBook
        };
        try
        {
            updateBookCmd.Handle();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = _context.Books.SingleOrDefault(x => x.Id == id);
        if (book is null)
            return BadRequest();

        _context.Books.Remove(book);

        _context.SaveChanges();
        return Ok();
    }
}

