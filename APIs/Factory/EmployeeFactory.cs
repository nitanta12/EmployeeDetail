using APIs.DTOs;
using AutoMapper;
using Domain.Models;

namespace APIs.Factory
{
    public class EmployeeFactory : IEmployeeFactory
    {
        // Auto Mapping
        private readonly IMapper _mapper;
        public EmployeeFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public EmployeeDto MapEmployeeEntityToDTO(EmployeeDetail entity)
        {
            var res = _mapper.Map<EmployeeDto>(entity);
            return res;

        }

        public EmployeeDetail MapEmployeeDtoToEntity(EmployeeDto dto)
        {
            var res = _mapper.Map<EmployeeDetail>(dto);
            return res;
        }


        //Manual Mapping
        //For get: Restrict the amount of the data shown. 
        public List<EmployeeDto> MapEntityToDto(List<EmployeeDetail> entity)
        {
            if (entity == null)
                return new List<EmployeeDto>();

            var emd = entity.Select(x => new EmployeeDto
            {
                Id =x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                DId = x.DId

            }).ToList();
            return emd;

        }


        //For post
        public EmployeeDetail MapDtoToEntity(EmployeeDto dto, EmployeeDetail entity)
        {
            if (dto.Id != null)
                entity.Id = dto.Id.Value;

            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.Address = dto.Address;
            entity.Enrollment = dto.Enrollment;
            entity.DateOfBirth = dto.DateOfBirth;
            entity.DId = dto.DId;
           
            return entity;
        }
    }
}