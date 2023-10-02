using AutoMapper;
using employeeTask.DTO;
using employeeTask.Models;
using System.Linq;

namespace employeeTask.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            CreateMap<Employee, EmployeeDTO>() .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses));
            CreateMap<Address, AddressDTo>();



            //CreateMap<AddEmployeeDTO, Employee>().ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses)); 
            //CreateMap<AddressDTo, Address>();
        }
      
       
    }
}
