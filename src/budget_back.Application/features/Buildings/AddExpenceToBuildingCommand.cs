using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Buildings;

public record AddExpenceToBuildingCommand(
    int Id,
    string Description,
    decimal Amount,
    int? BankAccountId) : IRequest<AddExpenceToBuildingResult>;

public record AddExpenceToBuildingResult(
    bool EntityFound,
    bool BankAccountFound,
    ExpenceResponse? Expence);

public class AddExpenceToBuildingCommandHandler(IBudgetDbContext context)
    : IRequestHandler<AddExpenceToBuildingCommand, AddExpenceToBuildingResult>
{
    public async Task<AddExpenceToBuildingResult> Handle(
        AddExpenceToBuildingCommand request,
        CancellationToken cancellationToken)
    {
        var building = await context.Buildings
            .Include(item => item.ExpenseScope)
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (building is null)
        {
            return new AddExpenceToBuildingResult(false, false, null);
        }

        if (request.BankAccountId is int bankAccountId)
        {
            var bankAccountExists = await context.BankAccounts
                .AnyAsync(account => account.Id == bankAccountId, cancellationToken);

            if (!bankAccountExists)
            {
                return new AddExpenceToBuildingResult(true, false, null);
            }
        }

        var expence = building.AddExpence(request.Description, request.Amount, request.BankAccountId);
        await context.SaveChangesAsync(cancellationToken);
        return new AddExpenceToBuildingResult(true, true, expence.ToResponse());
    }
}
