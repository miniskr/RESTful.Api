using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RESTful.API.DtoParmeters;
using RESTful.API.Entities;
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

        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies([FromQuery]CompanyDtoParameters parameters)
        {
            var companies = await this._companyRepository.GetCompaniesAsync(parameters);

            var companyDtos = this._mapper.Map<IEnumerable<CompanyDto>>(companies);
            return Ok(companyDtos);
        }

        [HttpGet("{companyId}", Name = nameof(GetCompany))]
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

        [HttpPost]
        public async Task<ActionResult<CompanyDto>> CreateCompany([FromBody]CompanyAddDto company)
        {
            var entity = this._mapper.Map<Company>(company);

            this._companyRepository.AddCompany(entity);

            await this._companyRepository.SaveAsync();

            var returnDto = this._mapper.Map<CompanyDto>(entity);
            return CreatedAtAction(nameof(GetCompany), new { companyId = returnDto.Id }, returnDto);
        }
    }
}
