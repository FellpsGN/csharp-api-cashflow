using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using CashFlow.Infrastructure.DataAccess.Repositories;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IExpenseRepository, ExpensesRepository>();
    }
    private static void AddDbContext(IServiceCollection services)
    {
        services.AddDbContext<CashFlowDbContext>();
    }
    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddRepositories(services);
        AddDbContext(services);
    }
}