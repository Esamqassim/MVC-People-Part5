using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDB.Models
{
    public class PeopleService : IPeopleService

    {
        readonly private static List<Person> personDB = new List<Person>();
        private static int idCounter = 0;
       static List<string>personOld = new List<string>();

        //Added

        bool myBool = false;

        //Injection

        private readonly IPeopleRepo _iPeopleRepo;

        public PeopleService() 
        {
             if ((personDB.Count==0)&(myBool == true))//To ensure initail Data base does not duplicate!
            {
               // personOld.Add("");//To ensure initail Data base does not duplicate!
                 personDB.Add(new Person() { Id= ++idCounter, FirstName ="Esam", LastName ="Alkureishi",
                                                                PhoneNumber="070xxxxxxx",CityName="Nässjö" });

                 personDB.Add(new Person()  {  Id = ++idCounter,FirstName = "Dhrgham",  LastName = "Qassim",
                                              PhoneNumber = "070xxxxxxx",CityName = "Nässjö"
                 });

                personDB.Add(new Person()
                {
                    Id = ++idCounter,
                    FirstName = "Ali",
                    LastName = "Hussien",
                    PhoneNumber = "070xxxxxxx",
                    CityName = "Nässjö"
                });
                 myBool = true;
            }//End if

           // _iPeopleRepo = iPeopleRepo;

        }
        public Person PersonAdd(CreatePersonViewModel person)//model view such as Car
        {
            Person per=new Person() {
                Id = ++idCounter,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber,
                CityName = person.CityName
                };

            personDB.Add(per);
            return per;
        }

        public List<Person> All()//call it instead in controller
        {
            return personDB;
        }

        public bool Edit(int id, CreatePersonViewModel person)//model view
        {
            if (id == person.Id)
            {
                //Update Person
                Person per = new Person()
                {
                    Id = ++idCounter,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    PhoneNumber = person.PhoneNumber,
                    CityName = person.CityName
                };

                personDB.Add(per);

                return true;
            }

            else
                return false;
        }//End edit

        public Person FindById(int id)
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

        public bool Remove(int id)
        {
            foreach (Person per in personDB)
            {
                if (per.Id == id)
                {
                    per.Id = 0;
                    return true;
                }
            }

            return false;
        }

        public List<Person> Search(string search)
        {
            List<Person> personList = new List<Person>();//Store persons

            if (search != null)
            {
                foreach (Person per in personDB)
                {

                    if (search.Contains(per.CityName))
                    {
                        // return personDB;//It will exit loop & return just one
                        personList.Add(per);
                    }
                    if (search.Contains(per.FirstName))
                    {
                        // return personDB;
                        personList.Add(per);
                    }
                    if (search.Contains(per.LastName))
                    {
                        //return personDB;
                        personList.Add(per);
                    }

                }
            }
            return personList;
        }//End search

        //Added by me
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
        public List<Person> GetPerson()//Will be called in controller, It s not needed
        {
            return personDB;
        }
    }
}
