using System;

namespace RESTful.API.DtoParmeters
{
    public class CompanyDtoParameters
    {
        //! 过滤参数
        public string CompanyName { get; set; }

        //! 检索参数
        public string SearchTerm { get; set; }
    }
}
