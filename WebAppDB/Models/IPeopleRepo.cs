using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDB.Models
{
  public  interface IPeopleRepo
    {
        //do sth
        Person Create(Person person);
        List<Person> Read();
        Person Read(int id);
        bool Update(Person person);
        bool Delete(Person person);

        //Added by me

       // Person All();//It will be used instead of ( List<Person> Read(); above)

    }
}
