using budget_back.Application.Response;
using budget_back.Domain.AggregatedModels;

namespace budget_back.Application.Mappings;

public static class ExpenceMappings
{
    public static ExpenceResponse ToResponse(this Expence expence)
    {
        return new ExpenceResponse(
            expence.Id,
            expence.Description,
            expence.Amount,
            expence.CreatedAt,
            expence.UpdatedAt,
            expence.ExpenseScopeId,
            expence.BankAccountId);
    }
}
