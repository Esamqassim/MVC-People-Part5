using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDB.Models
{
    public class CreatePersonViewModel //Make it identical to Person to easy to assign properties!
    {
        [Required]       
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string CityName { get; set; }

        public List<Person> PersonList { get; set; }
    }
}
