using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.GenreOperations.Commands.CreateGenre;
using MyApp.Application.GenreOperations.Commands.DeleteGenre;
using MyApp.Application.GenreOperations.Commands.UpdateGenre;
using MyApp.Application.GenreOperations.Querys;
using MyApp.Application.GenreOperations.Querys.GetGenreQueryDetail;
using MyApp.DBOperation;
using MyApp.DBOperations;
using static MyApp.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using static MyApp.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly IBookStoreDBContext _context;
        private readonly IMapper _mapper;

        public GenreController(IBookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetGenresQuery genreQuery = new GetGenresQuery(_context, _mapper);
            var result = genreQuery.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetGenreQueryDetailValidator validator = new GetGenreQueryDetailValidator();
            GetGenreQueryDetail genreByIdQuery = new GetGenreQueryDetail(_context, _mapper)
            {
                genreId = id
            };
            validator.ValidateAndThrow(genreByIdQuery);
            GenreDetailViewModel result = genreByIdQuery.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context)
            {
                model = newGenre
            };
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateGenreModel updateGenre)
        {

            UpdateGenreCommand updateGenreCommand = new UpdateGenreCommand(_context)
            {
                updateModel = updateGenre,
                genreId = id
            };

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(updateGenreCommand);
            updateGenreCommand.Handle();
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context)
            {
                genreId = id
            };

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }
}