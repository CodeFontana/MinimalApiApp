using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces;
public interface IPersonRepository
{
    Task<int> Create(PersonModel person);
    Task Delete(int id);
    Task<PersonModel?> Read(int id);
    Task<IEnumerable<PersonModel>> ReadAll();
    Task Update(PersonModel person);
}