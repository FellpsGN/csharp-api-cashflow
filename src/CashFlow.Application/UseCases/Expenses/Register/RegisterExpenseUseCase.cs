using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpenseRepository _expenseRepository;
    public RegisterExpenseUseCase(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }
    private void Validate(RequestRegisterExpenseJson request)
    {
        var expenseValidator = new RegisterExpenseValidator();
        var expenseValidationResult = expenseValidator.Validate(request);

        if (!expenseValidationResult.IsValid)
        {
            var expenseErrorsMessage = expenseValidationResult.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrorOnValidationException { ErrorMessages = expenseErrorsMessage };
        }
    }
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        var entity = new Expense
        {
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            Title = request.Title,
            PaymentType = (Domain.Enums.PaymentType)request.PaymentType
        };
        
        _expenseRepository.Add(entity);
        
        return new ResponseRegisterExpenseJson
        {
            
        };
    }
}