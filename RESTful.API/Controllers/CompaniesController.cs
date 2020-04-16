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
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompaniesController(
            ICompanyRepository companyRepository,
            IMapper mapper
            )
        {
            this._companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies()
        {
            var companies = await this._companyRepository.GetCompaniesAsync();

            var companyDtos = this._mapper.Map<IEnumerable<CompanyDto>>(companies);
            return Ok(companyDtos);
        }

        [HttpGet("{companyId}")]
        public async Task<ActionResult<CompanyDto>> GetCompany([FromRoute]Guid companyId)
        {
            var exist = await this._companyRepository.CompanyExistsAsync(companyId);
            //! 第一种写法，并发问题
            //if (!exist)
            //    return NotFound();

            var company = await this._companyRepository.GetCompanyAsync(companyId);
            //! 第二种写法
            if (company == null)
                return NotFound();

            return Ok(this._mapper.Map<CompanyDto>(company));
        }
    }
}
