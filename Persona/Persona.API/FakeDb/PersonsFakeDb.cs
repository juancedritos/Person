using Persona.API.Models;
using System.Collections.Generic;

namespace Persona.API.FakeDB
{
    public class PersonsFakeDb
    {
        private List<Person> _fakePerson = new List<Person>
        {
            new Person
            {
                Id = 1,
                Name = "Juan",
                Age = 25,
                Email = "jcgs2001@msn.com",
                Adress = "Cll 184 11- 75",
                Phone = "2345678",
                Mobile = "3016417088",
                State = true,
                BirthDate = System.DateTime.Now
            },
            new Person
            {
                Id = 2,
                Name = "Carolina",
                Age = 25,
                Email = "caro@msn.com",
                Adress = "Cll 184 11- 75",
                Phone = "2345678",
                Mobile = "3016417088",
                State = true,
                BirthDate = System.DateTime.Now,
                ZipCode = 110141
            },
            new Person
            {
                Id = 3,
               Name = "Maria",
                Age = 25,
                Email = "Maria@msn.com",
                Adress = "Cll 184 11- 75",
                Phone = "2345678",
                Mobile = "3016417088",
                State = true,
                BirthDate = System.DateTime.Now,
                ZipCode = 110141
            },
            new Person
            {
                Id = 4,
                Name = "Lucas",
                Age = 25,
                Email = "lucas@msn.com",
                Adress = "Cll 184 11- 75",
                Phone = "2345678",
                Mobile = "3016417088",
                State = true,
                BirthDate = System.DateTime.Now,
                ZipCode = 110141
            },
            new Person
            {
                Id = 5,
                Name = "Eduardo",
                Age = 25,
                Email = "Edward@msn.com",
                Adress = "Cll 184 11- 75",
                Phone = "2345678",
                Mobile = "3016417088",
                State = true,
                BirthDate = System.DateTime.Now,
                ZipCode = 110141v
            },
        };
        public List<Person> FakePersons
        {
            get
            {
                return _fakePerson;
            }
            set
            {
                _fakePerson = FakePersons;
            }
        }
    }
}
