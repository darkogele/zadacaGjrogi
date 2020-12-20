using SchoolApi.Contracts;
using SchoolApi.Data.Entites;
using System;
using System.Collections;
using System.Linq;

namespace SchoolApi.Data.SchoolDbContext
{
    public class CompanyRepo : ICompanyRepository
    {
        private readonly SchoolDbContext _context;

        public CompanyRepo(SchoolDbContext context)
        {
            _context = context;
        }
        public void DeleteCompany(int customerId)
        {
            var companyFromDb = _context.Companies.Find(customerId);
            companyFromDb.DeletedOn = DateTime.Now;
        }

        public IEnumerable GetCompanies()
        {
            return _context.Companies.Where(x => x.DeletedOn == null).ToList();
        }

        public Company GetCompanyById(int id)
        {
            return _context.Companies.FirstOrDefault(c => c.DeletedOn.Equals(null)
                && c.Id.Equals(id));
        }

        public void InsertCompany(Company company)
        {
            _context.Companies.Add(company);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 1;
        }

        public void UpdateCompany(Company company)
        {
            var companyFromDb = _context.Companies.Find(company.Id);
            companyFromDb.ModifedOn = DateTime.Now;
            companyFromDb.Name = company.Name;
            companyFromDb.PhoneNumber = company.PhoneNumber;
            companyFromDb.Email = company.Email;
        }
    }
}
