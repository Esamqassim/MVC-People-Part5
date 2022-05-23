using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Models;

namespace WebAppDB.Models
{
  public  interface IPeopleService
    {
        Person PersonAdd(CreatePersonViewModel person);
        List<Person> All();
        List<Person> Search(string search);
        Person FindById(int id);
        bool Edit(int id, CreatePersonViewModel person);
        bool Remove(int id);

        //added by me
         bool Delete(Person person);
    }
}
