using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDB.Models
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> personDB= new List<Person>();
        private static int idCounter=0;
      

        public Person Create(Person person)
        {
            Person pers = new Person() { Id = ++idCounter, FirstName = person.FirstName, LastName = person.LastName,
                                         PhoneNumber = person.PhoneNumber, CityName = person.CityName };
            personDB.Add(pers);
            return pers;
        }

        public bool Delete(Person person)
        {
            if (personDB.Contains(person))
            {
                personDB.Remove(person);
                return true;
            }

            else
                return false;

        }

        public List<Person> Read()
        {
            return personDB;
        }

        public Person Read(int id)
        {
            for (int i = 0; i < personDB.Count; i++)
            {


                Person findId = personDB[i];
                int id2 = findId.Id;
                if (id2 == id)
                {
                    Person availble = personDB[i];
                    return availble;
                }
            }
            return null;
        }

        public bool Update(Person person)//do sth
        {
            throw new NotImplementedException();
        }
    }
}
