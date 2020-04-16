using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RESTful.API.Models;
using RESTful.API.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTful.API.Controllers
{
    [ApiController]
    [Route("api/companies/{companyId}/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public EmployeesController(
            IMapper mapper,
            ICompanyRepository companyRepository
            )
        {
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesForCompany(Guid companyId)
        {
            if (!await this._companyRepository.CompanyExistsAsync(companyId))
                return NotFound($"can not found employees from {companyId}");

            var employees = await this._companyRepository.GetEmployeesAsync(companyId);
            var employeeDtos = this._mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return Ok(employeeDtos);
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeForCompany(Guid companyId, Guid employeeId)
        {
            if (!await this._companyRepository.CompanyExistsAsync(companyId))
                return NotFound($"can not found employees from {companyId}");

            var employee = await this._companyRepository.GetEmployeeAsync(companyId, employeeId);
            if (employee == null)
                return NotFound();

            var employeeDto = this._mapper.Map<EmployeeDto>(employee);

            return Ok(employeeDto);
        }
    }
}
