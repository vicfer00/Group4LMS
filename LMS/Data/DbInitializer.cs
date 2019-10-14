using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any books.
            if (context.Book.Any())
            {
                return;   // DB has been seeded
            }

            var books = new Book[]
            {
            new Book{ISBN="123-12345679679",Title="The Alchemist",Author="Gerard Butler",Publisher="Cool Books",
                Genre="Science Fiction",Price=20},
            new Book{ISBN="123-12349340648",Title="The Mist",Author="Wolverine Butler",Publisher="X Books",
                Genre="Science Fiction",Price=35},
            new Book{ISBN="123-915234568245",Title="Sorcerer's Ring",Author="Morgan Rice",Publisher="Epic",
                Genre="Science Fiction",Price=15},
           new Book{ISBN="123-1236734154",Title="The Great Gatsby",Author="F. Scott Fitzgerald",Publisher="Scribner",
               Genre="Historical Fiction",Price=12},
           new Book{ISBN="123-1532971632",Title="The Grapes of Wrath",Author="John Steinback",Publisher="X Books",
               Genre="Historical Fiction",Price=25},
           new Book{ISBN="123-1763215464",Title="1984",Author="George Orwell",Publisher="Berkley",
               Genre="Science Fiction",Price=5},
           new Book{ISBN="123-6198345742",Title="Lolita",Author="Vladimir Nabokov",Publisher="Vintage",
               Genre="Romance",Price=30},
           new Book{ISBN="123-9132647965",Title="Beloved",Author="Toni Morrison",Publisher="Vintage",
               Genre="Historical Fiction",Price=14},
           new Book{ISBN="123-1275624684",Title="To Kill a Mockingbird",Author="Harper Lee",Publisher="Harper",
               Genre="Historical Fiction",Price=9},
           new Book{ISBN="123-3246289375",Title="The Lord of the Rings",Author="J. R. R. Tolkien",Publisher="Mariner Books",
               Genre="Fantasy",Price=45},
           new Book{ISBN="123-2248756391",Title="Invisible Man",Author="Ralph Ellison",Publisher="Vintage",
               Genre="Historical Fiction",Price=15},
           new Book{ISBN="123-5324796514",Title="Gone with the Wind",Author="Margaret Mitchell",Publisher="Scribner",
               Genre="Historical Fiction",Price=24},
            new Book{ISBN="123-345217986",Title="Jane Eyre",Author="Charlotte Brontë",Publisher="Dover Publications",
               Genre="Romance",Price=20},
           new Book{ISBN="123-4328961794",Title="Pride and Prejudice",Author="Jane Austen",Publisher="Tribeca Books",
               Genre="Romance",Price=35},
           new Book{ISBN="123-6327984213",Title="Lord of the Flies",Author="William Golding",Publisher="Penguin Books",
               Genre="Dystopia",Price=22},
           new Book{ISBN="123-5633217958",Title="Animal Farm",Author="George Orwell",Publisher="Houghton Mifflin Harcourt",
               Genre="Dystopia",Price=6},
           new Book{ISBN="123-1253798614",Title="Wuthering Heights",Author="Emily Brontë",Publisher="Harper Design",
               Genre="Romance",Price=15},
           new Book{ISBN="123-7325641239",Title="Winnie-the-Pooh",Author="A. A. Milne",Publisher="Dutton Books for Young Readers",
               Genre="Childrens",Price=20},
           new Book{ISBN="123-1256795432",Title="Of Mice and Men",Author="    John Steinbeck",Publisher="Pascal Covici",
               Genre="Historical Fiction",Price= 13},
           new Book{ISBN="123-9873654124",Title="Moby-Dick",Author="Herman Melville",Publisher="CreateSpace Independent Publishing Platform",
               Genre="Adventure",Price=15},
           new Book{ISBN="123-2367954129",Title="The Hitchhiker's Guide to the Galaxy",Author="Douglas Adams",Publisher="Del Rey",
               Genre="Science Fiction",Price=19},
           new Book{ISBN="123-63217564231",Title="The Hobbit",Author="    J. R. R. Tolkien",Publisher="Houghton Mifflin Harcourt",
               Genre="Fantasy",Price=20}
            };
            foreach (Book s in books)
            {
                context.Book.Add(s);
            }
            context.SaveChanges();

            var patrons = new Patron[]
            {
            new Patron{FirstName="Sam",LastName="Chemistry",DOB=DateTime.ParseExact("1990-06-10", "yyyy-mm-dd",null),PhoneNumber = "832-123-4862"},
          new Patron{FirstName="Edwin",LastName="Herrera",DOB=DateTime.ParseExact("1992-09-10", "yyyy-mm-dd",null),PhoneNumber = "281-321-4851"},
          new Patron{FirstName="Laura",LastName="Adams",DOB=DateTime.ParseExact("1987-12-26", "yyyy-mm-dd",null),PhoneNumber = "281-789-2689"},
          new Patron{FirstName="Nafiset",LastName="Maddison",DOB=DateTime.ParseExact("1962-03-24", "yyyy-mm-dd",null),PhoneNumber = "281-762-1597"},
          new Patron{FirstName="Jordi",LastName="Quirinus",DOB=DateTime.ParseExact("1966-05-20", "yyyy-mm-dd",null),PhoneNumber = "832-164-7328"},
          new Patron{FirstName="Anatolijs",LastName="Chiemeka",DOB=DateTime.ParseExact("1985-02-18", "yyyy-mm-dd",null),PhoneNumber = "713-113-2795"},
          new Patron{FirstName="Mate",LastName="Lucius",DOB=DateTime.ParseExact("1981-07-14", "yyyy-mm-dd",null),PhoneNumber = "832-912-6467"},
          new Patron{FirstName="Pooja",LastName="Fredrika",DOB=DateTime.ParseExact("1996-01-01", "yyyy-mm-dd",null),PhoneNumber = "713-987-5642"},
          new Patron{FirstName="Vida",LastName="Suz",DOB=DateTime.ParseExact("1988-01-29", "yyyy-mm-dd",null),PhoneNumber = "713-544-6487"},
          new Patron{FirstName="Damjana",LastName="Danka",DOB=DateTime.ParseExact("1991-11-19", "yyyy-mm-dd",null),PhoneNumber = "832-643-9874"},
          new Patron{FirstName="Mihaela",LastName="Hanna",DOB=DateTime.ParseExact("1994-08-15", "yyyy-mm-dd",null),PhoneNumber = "832-777-4291"},
          new Patron{FirstName="Andria",LastName="Keane",DOB=DateTime.ParseExact("1992-10-11", "yyyy-mm-dd",null),PhoneNumber = "713-321-1234"}
            };
            foreach (Patron c in patrons)
            {
                context.Patron.Add(c);
            }
            context.SaveChanges();

            var rooms = new Room[]
            {
            new Room{RoomNumber = 300, Monitor = true, Whiteboard = false, MaxOccupancy = 4},
               new Room{RoomNumber = 301, Monitor = false, Whiteboard = true, MaxOccupancy = 6},
               new Room{RoomNumber = 302, Monitor = false, Whiteboard = false, MaxOccupancy = 4},
               new Room{RoomNumber = 110, Monitor = true, Whiteboard = false, MaxOccupancy = 8},
               new Room{RoomNumber = 111, Monitor = true, Whiteboard = true, MaxOccupancy = 6},
               new Room{RoomNumber = 203, Monitor = true, Whiteboard = true, MaxOccupancy = 8},
            new Room{RoomNumber=400,Monitor=false,Whiteboard=false,MaxOccupancy=6},
            new Room{RoomNumber=500,Monitor=true,Whiteboard=true,MaxOccupancy=4}
            };
            foreach (Room r in rooms)
            {
                context.Room.Add(r);
            }
            context.SaveChanges();

        }
    }
}
