using budget_back.Application.Features.Buildings;
using budget_back.Application.Request;
using budget_back.Application.Response;
using budget_back.Domain.AggregatedModels;

namespace budget_back.Application.Mappings;

public static class BuildingMappings
{
    public static CreateBuildingCommand ToCommand(this CreateBuildingRequest request)
    {
        return new CreateBuildingCommand(
            request.Name,
            request.ManagerId,
            request.Description,
            request.Address);
    }

    public static UpdateBuildingCommand ToCommand(this UpdateBuildingRequest request, int id)
    {
        return new UpdateBuildingCommand(
            id,
            request.Name,
            request.ManagerId,
            request.Description,
            request.Address);
    }

    public static AddUsersToBuildingCommand ToAddUsersToBuildingCommand(this AddUsersRequest request, int id)
    {
        return new AddUsersToBuildingCommand(id, request.UserIds);
    }

    public static AddExpenceToBuildingCommand ToAddExpenceToBuildingCommand(this AddExpenceRequest request, int id)
    {
        return new AddExpenceToBuildingCommand(id, request.Description, request.Amount, request.BankAccountId);
    }

    public static BuildingResponse ToResponse(this Building building)
    {
        return new BuildingResponse(
            building.Id,
            building.Name,
            building.Description,
            building.Address,
            building.ManagerId,
            building.ExpenseScopeId,
            building.Users.Select(user => user.Id).ToList());
    }

    public static IReadOnlyList<BuildingResponse> ToResponse(this IEnumerable<Building> buildings)
    {
        return buildings.Select(ToResponse).ToList();
    }
}
