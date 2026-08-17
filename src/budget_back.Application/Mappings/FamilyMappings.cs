using budget_back.Application.Features.Families;
using budget_back.Application.Request;
using budget_back.Application.Response;
using budget_back.Domain.AggregatedModels;

namespace budget_back.Application.Mappings;

public static class FamilyMappings
{
    public static CreateFamilyCommand ToCommand(this CreateFamilyRequest request)
    {
        return new CreateFamilyCommand(
            request.Name,
            request.ManagerId,
            request.Description);
    }

    public static UpdateFamilyCommand ToCommand(this UpdateFamilyRequest request, int id)
    {
        return new UpdateFamilyCommand(
            id,
            request.Name,
            request.ManagerId,
            request.Description);
    }

    public static AddUsersToFamilyCommand ToAddUsersToFamilyCommand(this AddUsersRequest request, int id)
    {
        return new AddUsersToFamilyCommand(id, request.UserIds);
    }

    public static AddExpenceToFamilyCommand ToAddExpenceToFamilyCommand(this AddExpenceRequest request, int id)
    {
        return new AddExpenceToFamilyCommand(id, request.Description, request.Amount, request.BankAccountId);
    }

    public static FamilyResponse ToResponse(this Family family)
    {
        return new FamilyResponse(
            family.Id,
            family.Name,
            family.Description,
            family.ManagerId,
            family.ExpenseScopeId,
            family.Users.Select(user => user.Id).ToList());
    }

    public static IReadOnlyList<FamilyResponse> ToResponse(this IEnumerable<Family> families)
    {
        return families.Select(ToResponse).ToList();
    }
}
