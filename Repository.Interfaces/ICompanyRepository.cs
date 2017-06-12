using Entities;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface ICompanyRepository
    {
		bool Add(Company company);
		bool Update(Company company);
		bool Delete(int id);
		IList<Company> GetAll();
		Company GetById(int id);
	}
}
