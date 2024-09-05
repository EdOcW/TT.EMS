using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TT.EMS.Application.Employee.Commands.Create;
using TT.EMS.Application.Employee.Commands.DeleteRange;
using TT.EMS.Application.Employee.Commands.Update;
using TT.EMS.Application.Employee.Queries.GetAll;
using TT.EMS.Application.Employee.Queries.GetById;
using TT.EMS.Web.Api.Requests.Employee;
using TT.EMS.Web.Api.Responces.Employee;

namespace TT.EMS.Web.Api.Endpoints;

public static partial class Endpoints
{
    public static WebApplication RegisterEmployeeEndpoints(this WebApplication app)
    {
        app.MapGet("employees/{id:Guid}", async (ISender mediator, Guid id) =>
        {
            var query = new GetEmployeeByIdQuery(id);

            var queryResult = await mediator.Send(query);

            return queryResult.IsSuccess
                ? Results.Json(queryResult.Value.Adapt<EmployeeResponce>())
                : Results.BadRequest(queryResult.Error);
        });

        app.MapGet("employees", async (ISender mediator) =>
        {
            var query = new GetAllEmployeesQuery();

            var queryResult = await mediator.Send(query);

            return queryResult.IsSuccess
                ? Results.Json(queryResult.Value.Adapt<IReadOnlyCollection<EmployeeResponce>>())
                : Results.BadRequest(queryResult.Error);
        });

        app.MapPost("employees", async (ISender mediator, CreateEmployeeRequest request, CancellationToken cancellationToken) =>
        {
            var command = request.Adapt<CreateEmployeeCommand>();

            var commandResult = await mediator.Send(command, cancellationToken);

            return commandResult.IsSuccess
                ? Results.Created()
                : Results.BadRequest(commandResult.Error);
        });

        app.MapPut("employees/{id:Guid}", async (ISender mediator, Guid id, UpdateEmployeeRequest request, CancellationToken cancellationToken) =>
        {
            var command = (Id: id, Body: request).Adapt<UpdateEmployeeCommand>();

            var commandResult = await mediator.Send(command, cancellationToken);

            return commandResult.IsSuccess 
                ? Results.NoContent()
                : Results.BadRequest(commandResult.Error);
        });

        app.MapDelete("employees/", async (ISender mediator, [FromBody] IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken) =>
        {
            var command = new DeleteRangeEmployeesCommand(ids);

            var commandResult = await mediator.Send(command, cancellationToken);

            return commandResult.IsSuccess 
                ? Results.NoContent()
                : Results.BadRequest(commandResult.Error);
        });

        return app;
    }
}