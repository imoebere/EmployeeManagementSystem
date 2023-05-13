using AutoMapper;

namespace EmployeeMgt.Model
{
	public class EmployeeProfile : Profile
	{
        public EmployeeProfile()
        {
            CreateMap<Employee, EditEmployeeModel>()
                .ForMember(dest => dest.ConfirmEmail, 
                            opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
        }

    }
}
