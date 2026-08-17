using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Categories;

public record AddExpenceToCategoryCommand(
    int Id,
    string Description,
    decimal Amount,
    int? BankAccountId) : IRequest<AddExpenceToCategoryResult>;

public record AddExpenceToCategoryResult(
    bool EntityFound,
    bool BankAccountFound,
    ExpenceResponse? Expence);

public class AddExpenceToCategoryCommandHandler(IBudgetDbContext context)
    : IRequestHandler<AddExpenceToCategoryCommand, AddExpenceToCategoryResult>
{
    public async Task<AddExpenceToCategoryResult> Handle(
        AddExpenceToCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .Include(item => item.ExpenseScope)
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (category is null)
        {
            return new AddExpenceToCategoryResult(false, false, null);
        }

        if (request.BankAccountId is int bankAccountId)
        {
            var bankAccountExists = await context.BankAccounts
                .AnyAsync(account => account.Id == bankAccountId, cancellationToken);

            if (!bankAccountExists)
            {
                return new AddExpenceToCategoryResult(true, false, null);
            }
        }

        var expence = category.AddExpence(request.Description, request.Amount, request.BankAccountId);
        await context.SaveChangesAsync(cancellationToken);
        return new AddExpenceToCategoryResult(true, true, expence.ToResponse());
    }
}
