using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Data
{
    public class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();

            // Look for any books.
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }

            var books = new Book[]
            {
            new Book{BookID=1005,ISBN="123-1234567967",Title="The Alchemist",Author="Gerard Butler",Publisher="Cool Books",
                PublishDate =DateTime.Today,Genre="Science Fiction",Price=20,Available="Yes"},
            new Book{BookID=1010,ISBN="123-1234934064",Title="The Mist",Author="Wolverine Butler",Publisher="X Books",
                PublishDate =DateTime.Today,Genre="Science Fiction",Price=35,Available="Yes"}
            };
            foreach (Book s in books)
            {
                context.Books.Add(s);
            }
            context.SaveChanges();

            var members = new Member[]
            {
            new Member{FirstName="Sam",LastName="Chemistry",Email="chemistry.sam@yahoo.com",DOB=DateTime.Today.AddYears(-17),Active="Yes",Password="Unicorns"},
            new Member{FirstName="Edwin",LastName="Herrera",Email="herrera.edwin@yahoo.com",DOB=DateTime.Today.AddYears(-28),Active="Yes",Password="P@nth3on"}
            };
            foreach (Member c in members)
            {
                context.Members.Add(c);
            }
            context.SaveChanges();

            //var members = new Member[]
            //{
            //new Member{FirstName="Sam",LastName="Chemistry",Email="chemistry.sam@yahoo.com",DOB=DateTime.Today.AddYears(-17),Active="Yes",Password="Unicorns"},
            //new Member{FirstName="Edwin",LastName="Herrera",Email="herrera.edwin@yahoo.com",DOB=DateTime.Today.AddYears(-28),Active="Yes",Password="P@nth3on"}
            //};
            //foreach (Member c in members)
            //{
            //    context.Members.Add(c);
            //}
            //context.SaveChanges();
        }

    }
}
