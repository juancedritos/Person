using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persona.API.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public bool State { get; set; }
        public DateTime BirthDate { get; set; }
        public int ZipCode { get; set; }
    }
}
