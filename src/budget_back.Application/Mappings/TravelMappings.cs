using budget_back.Application.Features.Travels;
using budget_back.Application.Request;
using budget_back.Application.Response;
using budget_back.Domain.AggregatedModels;

namespace budget_back.Application.Mappings;

public static class TravelMappings
{
    public static CreateTravelCommand ToCommand(this CreateTravelRequest request)
    {
        return new CreateTravelCommand(
            request.ManagerId,
            request.Name,
            request.Description,
            request.StartDate,
            request.EndDate);
    }

    public static UpdateTravelCommand ToCommand(this UpdateTravelRequest request, int id)
    {
        return new UpdateTravelCommand(
            id,
            request.ManagerId,
            request.Name,
            request.Description,
            request.StartDate,
            request.EndDate);
    }

    public static AddUsersToTravelCommand ToAddUsersToTravelCommand(this AddUsersRequest request, int id)
    {
        return new AddUsersToTravelCommand(id, request.UserIds);
    }

    public static AddExpenceToTravelCommand ToAddExpenceToTravelCommand(this AddExpenceRequest request, int id)
    {
        return new AddExpenceToTravelCommand(id, request.Description, request.Amount, request.BankAccountId);
    }

    public static TravelResponse ToResponse(this Travel travel)
    {
        return new TravelResponse(
            travel.Id,
            travel.Name,
            travel.Description,
            travel.StartDate,
            travel.EndDate,
            travel.ManagerId,
            travel.ExpenseScopeId,
            travel.Users.Select(user => user.Id).ToList());
    }

    public static IReadOnlyList<TravelResponse> ToResponse(this IEnumerable<Travel> travels)
    {
        return travels.Select(ToResponse).ToList();
    }
}
