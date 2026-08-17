using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Travels;

public record AddExpenceToTravelCommand(
    int Id,
    string Description,
    decimal Amount,
    int? BankAccountId) : IRequest<AddExpenceToTravelResult>;

public record AddExpenceToTravelResult(
    bool EntityFound,
    bool BankAccountFound,
    ExpenceResponse? Expence);

public class AddExpenceToTravelCommandHandler(IBudgetDbContext context)
    : IRequestHandler<AddExpenceToTravelCommand, AddExpenceToTravelResult>
{
    public async Task<AddExpenceToTravelResult> Handle(
        AddExpenceToTravelCommand request,
        CancellationToken cancellationToken)
    {
        var travel = await context.Travels
            .Include(item => item.ExpenseScope)
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (travel is null)
        {
            return new AddExpenceToTravelResult(false, false, null);
        }

        if (request.BankAccountId is int bankAccountId)
        {
            var bankAccountExists = await context.BankAccounts
                .AnyAsync(account => account.Id == bankAccountId, cancellationToken);

            if (!bankAccountExists)
            {
                return new AddExpenceToTravelResult(true, false, null);
            }
        }

        var expence = travel.AddExpence(request.Description, request.Amount, request.BankAccountId);
        await context.SaveChangesAsync(cancellationToken);
        return new AddExpenceToTravelResult(true, true, expence.ToResponse());
    }
}
