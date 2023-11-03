using APIs.DTOs;
using Domain.Models;

namespace APIs.Factory
{
    public interface IEmployeeFactory
    {
        //For get------i.e Mapping the entity to dto we've mentioned.
        //EmployeeDto MapEmployeeEntityToDTO(EmployeeDetail entity);


        //for post-------i.e Mapping dto to entity so that entity gets save in database and get can call those attribute defined in dto.
        //EmployeeDetail MapEmployeeDtoToEntity(EmployeeDto dto);

        List<EmployeeDto> MapEntityToDto(List<EmployeeDetail> entity);

        EmployeeDetail MapDtoToEntity(EmployeeDto dto , EmployeeDetail entity);
       
    }
}
