using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Repository.Interfaces;

namespace ASP.NETCoreWebAPIWithDapperAndAutofac.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Company")]
    public class CompanyController : Controller
    {
		ICompanyRepository _companyRepository;

		public CompanyController(ICompanyRepository companyRepository)
		{
			_companyRepository = companyRepository;
		}
		
		// GET: api/company
		[HttpGet]
		public IEnumerable<Company> Get()
		{
			return _companyRepository.GetAll();
		}

		// GET api/company/5
		[HttpGet("{id}")]
		public Company Get(int id)
		{
			return _companyRepository.GetById(id);
		}

		// POST api/company
		[HttpPost]
		public void Post([FromBody]Company com)
		{
			_companyRepository.Add(com);
		}

		// PUT api/company/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]Company comp)
		{
			_companyRepository.Update(comp);
		}

		// DELETE api/company/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_companyRepository.Delete(id);
		}
	}
}