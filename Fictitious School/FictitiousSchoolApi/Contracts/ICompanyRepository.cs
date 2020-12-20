using SchoolApi.Data.Entites;
using System.Collections;

namespace SchoolApi.Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable GetCompanies();

        Company GetCompanyById(int id);

        void InsertCompany(Company company);

        void DeleteCompany(int customerId);

        void UpdateCompany(Company company);

        bool Save();
    }
}