using CashFlow.Application.UseCases.Expenses.Register;
using Microsoft.AspNetCore.Mvc;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.API.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
        {
            try
            {
                var useCase = new RegisterExpenseUseCase();
                var response = useCase.Execute(request);
                return Created(string.Empty, response);
            }
            catch (ArgumentException ex)
            {
                var errorResponse = new ResponseErrorJson { ErrorMessage = ex.Message };
                return BadRequest(errorResponse);
            }
            catch
            {
                var errorResponse = new ResponseErrorJson { ErrorMessage = "Unknow error." };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
            
        }
    }

