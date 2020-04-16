﻿using Microsoft.EntityFrameworkCore;
using RESTful.API.Data;
using RESTful.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful.API.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly RoutineDbContext _context;

        public CompanyRepository(RoutineDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Company> GetCompanyAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
                throw new ArgumentNullException(nameof(companyId));

            return await this._context.Companies.FirstOrDefaultAsync(x => x.Id == companyId);
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await this._context.Companies.ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<Guid> companyIds)
        {
            if (companyIds == null)
                throw new ArgumentNullException(nameof(companyIds));

            return await this._context.Companies
                .Where(x => companyIds.Contains(x.Id))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public void AddCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            company.Id = Guid.NewGuid();
            foreach (var employee in company.Employees)
            {
                employee.Id = Guid.NewGuid();
            }

            this._context.Add(company);
        }

        public void UpdateCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

        }

        public void DeleteCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            this._context.Companies.Remove(company);
        }

        public async Task<bool> CompanyExistsAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
                throw new ArgumentNullException(nameof(companyId));

            return await this._context.Companies.AnyAsync(x => x.Id == companyId);
        }

        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId)
        {
            if (companyId == Guid.Empty)
                throw new ArgumentNullException(nameof(companyId));
            if (employeeId == Guid.Empty)
                throw new ArgumentNullException(nameof(employeeId));

            return await this._context.Employees
                .Where(x => x.CompanyId == companyId && x.Id == employeeId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
                throw new ArgumentNullException(nameof(companyId));

            return await this._context.Employees
                .Where(x => x.CompanyId == companyId)
                .OrderBy(x => x.EmployeeNo)
                .ToListAsync();
        }

        public void AddEmployee(Guid companyId, Employee employee)
        {
            if (companyId == Guid.Empty)
                throw new ArgumentNullException(nameof(companyId));
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            employee.CompanyId = companyId;
            this._context.Employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            // this._context.Entry(employee).State = EntityState.Modified;
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            this._context.Employees.Remove(employee);
        }

        public async Task<bool> SaveAsync()
        {
            return await this._context.SaveChangesAsync() >= 0;
        }
    }
}
