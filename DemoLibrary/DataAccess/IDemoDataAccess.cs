using DemoLibrary.Models;

namespace DemoLibrary.DataAccess
{
    public interface IDemoDataAccess
    {
        List<PersonModel> GetAllPeople();
        PersonModel InsertPerson(string firstName, string lastName);
    }
}