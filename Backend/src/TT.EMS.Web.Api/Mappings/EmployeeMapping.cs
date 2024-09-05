using Mapster;
using TT.EMS.Application.Employee.Commands.Create;
using TT.EMS.Application.Employee.Commands.Update;
using TT.EMS.Application.Employee.Models;
using TT.EMS.Domain.Employee;
using TT.EMS.Web.Api.Requests.Employee;
using TT.EMS.Web.Api.Responces.Employee;

namespace TT.EMS.Web.Api.Mappings;

internal sealed class EmployeeMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(Guid Id, UpdateEmployeeRequest Body), UpdateEmployeeCommand>()
            .MapToConstructor(true)
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.FirstName, src => src.Body.FirstName)
            .Map(dest => dest.LastName, src => src.Body.LastName)
            .Map(dest => dest.Age, src => src.Body.Age)
            .Map(dest => dest.Sex, src => src.Body.Sex);

        config.NewConfig<CreateEmployeeRequest, CreateEmployeeCommand>()
            .MapToConstructor(true)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Age, src => src.Age)
            .Map(dest => dest.Sex, src => src.Sex);
        
        config.NewConfig<Employee, EmployeeDto>()
            .MapToConstructor(true)
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Age, src => src.Age)
            .Map(dest => dest.Sex, src => src.Sex);

        config.NewConfig<EmployeeDto, EmployeeResponce>()
            .MapToConstructor(true)
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Age, src => src.Age)
            .Map(dest => dest.Sex, src => src.Sex);
    }
}