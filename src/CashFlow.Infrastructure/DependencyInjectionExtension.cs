using CashFlow.Domain.Repositories.Expenses;
using Microsoft.Extensions.DependencyInjection;
using CashFlow.Infrastructure.DataAccess.Repositories;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IExpenseRepository, ExpensesRepository>();
    }
}