using Dapper;
using Entities;
using Repository.Interfaces;
using System;
using static System.Data.CommandType;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{

	public class CompanyRepository : BaseRepository, ICompanyRepository
	{
		public bool Add(Company company)
		{
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@comp_id", 0);
				parameters.Add("@comp_name", company.name);
				parameters.Add("@comp_description", company.description);
				parameters.Add("@comp_email", company.email);
				parameters.Add("@comp_address", company.address);
				parameters.Add("@comp_zipcode", company.zipcode);
				parameters.Add("@comp_person_no", company.person_no);
				parameters.Add("@comp_city_id", company.city_id);
				parameters.Add("@comp_phone_no", company.phone_no);
				parameters.Add("@comp_state_id", company.state_id);
				parameters.Add("@comp_is_active", company.is_active);
				SqlMapper.Execute(con, "company_create", param: parameters, commandType: StoredProcedure);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool Update(Company company)
		{
			try
			{ 
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@comp_id", company.id);
				parameters.Add("@comp_name", company.name);
				parameters.Add("@comp_description", company.description);
				parameters.Add("@comp_email", company.email);
				parameters.Add("@comp_address", company.address);
				parameters.Add("@comp_zipcode", company.zipcode);
				parameters.Add("@comp_person_no", company.person_no);
				parameters.Add("@comp_city_id", company.city_id);
				parameters.Add("@comp_phone_no", company.phone_no);
				parameters.Add("@comp_state_id", company.state_id);
				parameters.Add("@comp_is_active", company.is_active);
				SqlMapper.Execute(con, "company_create", param: parameters, commandType: StoredProcedure);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public bool Delete(int id)
		{
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@company_id", id);
			SqlMapper.Execute(con, "company_delete", param: parameters, commandType: StoredProcedure);
			return true;
		}
		public IList<Company> GetAll() => SqlMapper.Query<Company>(con, "company_get", commandType: StoredProcedure).ToList();
		public Company GetById(int id)
		{
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@company_id", id);
				return SqlMapper.Query<Company>(con, "company_getById", parameters, commandType: StoredProcedure).FirstOrDefault();
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}