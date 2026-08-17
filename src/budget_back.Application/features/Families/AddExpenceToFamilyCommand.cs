using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Families;

public record AddExpenceToFamilyCommand(
    int Id,
    string Description,
    decimal Amount,
    int? BankAccountId) : IRequest<AddExpenceToFamilyResult>;

public record AddExpenceToFamilyResult(
    bool EntityFound,
    bool BankAccountFound,
    ExpenceResponse? Expence);

public class AddExpenceToFamilyCommandHandler(IBudgetDbContext context)
    : IRequestHandler<AddExpenceToFamilyCommand, AddExpenceToFamilyResult>
{
    public async Task<AddExpenceToFamilyResult> Handle(
        AddExpenceToFamilyCommand request,
        CancellationToken cancellationToken)
    {
        var family = await context.Families
            .Include(item => item.ExpenseScope)
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (family is null)
        {
            return new AddExpenceToFamilyResult(false, false, null);
        }

        if (request.BankAccountId is int bankAccountId)
        {
            var bankAccountExists = await context.BankAccounts
                .AnyAsync(account => account.Id == bankAccountId, cancellationToken);

            if (!bankAccountExists)
            {
                return new AddExpenceToFamilyResult(true, false, null);
            }
        }

        var expence = family.AddExpence(request.Description, request.Amount, request.BankAccountId);
        await context.SaveChangesAsync(cancellationToken);
        return new AddExpenceToFamilyResult(true, true, expence.ToResponse());
    }
}
