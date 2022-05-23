using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Data;

namespace WebAppDB.Models
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        readonly MyDbContext _peopleDbContext;
        private static int idCounter = 0;

        //
        public DatabasePeopleRepo(MyDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        
                       
        }//End constructor

        //Inital DB 
        public static void Initialize(MyDbContext peopleDbContext)
        {

            peopleDbContext.Database.EnsureCreated();

            // Look for any students.
            if (peopleDbContext.Pepoles.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Person[]
            { new Person() { Id= ++idCounter, FirstName ="Esam", LastName ="Alkureishi",
                                                                PhoneNumber="070xxxxxxx",CityName="Nässjö" },
             new Person() { Id= ++idCounter, FirstName ="David", LastName ="Karl",
                                                                PhoneNumber="070xxxxxxx",CityName="Nässjö" }

            };//end array

            foreach (Person s in students)
            {
                // peopleDbContext.Pepole.Add(s);//Getproblem
                peopleDbContext.Pepoles.Add(s);

            }
            peopleDbContext.SaveChanges();

        }//End Initailize


            public Person Create(Person person)//Ok
        {
            _peopleDbContext.Add(person);//?!
            _peopleDbContext.SaveChanges();
            return person;
        }

        public bool Delete(Person person)
        {
            //throw new NotImplementedException();
            _peopleDbContext.Pepoles.Remove(person);
            return (_peopleDbContext.SaveChanges()>0);
        }

        public List<Person> Read()//Ok work
        {
            /* return _peopleDbContext.Pepoles.Include(b => b)
                 .ToList();//Persons changed to Pepoles prperty in context
            */
            return _peopleDbContext.Pepoles.ToList();
        }
      

        public Person Read(int id)
        {
            //  throw new NotImplementedException();
            return _peopleDbContext.Pepoles     //Not sure
                
                 .SingleOrDefault(book => book.Id == id);
        }

        public bool Update(Person person)
        {
            //throw new NotImplementedException();
            _peopleDbContext.Pepoles.Update(person);
            return (_peopleDbContext.SaveChanges() > 0);
        }
    }
}
