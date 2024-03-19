using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Entities;

namespace MyApp.DBOperations
{
    public interface IBookStoreDBContext
    {
        DbSet<Book> Books {get; set;}
        DbSet<Genre> Genres {get; set;}
        DbSet<User> Users {get; set;}

        int SaveChanges();
    }
}