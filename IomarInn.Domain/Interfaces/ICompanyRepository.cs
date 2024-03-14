using IomarInn.Domain.Entities;

namespace IomarInn.Domain.Interfaces;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetCompanies();
    Task<Company> GetById(int? id);
    Task<Company> Update(Company company);
    Task<Company> Create(Company company);
    Task<Company> Remove(Company company);
}