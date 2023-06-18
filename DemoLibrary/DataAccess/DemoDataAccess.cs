using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.DataAccess
{
    public class DemoDataAccess : IDemoDataAccess
    {
        private List<PersonModel> personList = new List<PersonModel>();

        public DemoDataAccess()
        {
            personList.Add(new PersonModel { Id = 1, FirstName = "Henry", LastName = "Steve" });
            personList.Add(new PersonModel { Id = 2, FirstName = "Shaun", LastName = "Smith" });
        }

        public List<PersonModel> GetAllPeople()
        {
            return personList;
        }

        public PersonModel InsertPerson(string firstName, string lastName)
        {
            PersonModel person = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Id = personList.Max(x => x.Id) + 1
            };

            personList.Add(person);

            return person;
        }

    }
}
