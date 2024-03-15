using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyApp.BookOperations.CreateBook;
using MyApp.BookOperations.DeleteCommand;
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
        GetBooksQuery booksQuery = new GetBooksQuery(_context, _mapper);
        var result = booksQuery.Handle();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        GetBookByIdValidator validator = new GetBookByIdValidator();
        GetBookByIdQuery bookByIdQuery = new GetBookByIdQuery(_context, _mapper)
        {
            bookId = id
        };
        validator.ValidateAndThrow(bookByIdQuery);
        var result = bookByIdQuery.Handle();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookModel newBook)
    {
        CreateBookCommand command = new CreateBookCommand(_context, _mapper)
        {
            Model = newBook
        };
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        _context.SaveChanges();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
    {

        UpdateBookCommand updateBookCommand = new UpdateBookCommand(_context)
        {
            bookId = id,
            updateModel = updateBook
        };

        UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
        validator.ValidateAndThrow(updateBookCommand);
        updateBookCommand.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        DeleteCommand command = new DeleteCommand(_context)
        {
            bookId = id
        };

        DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
}

