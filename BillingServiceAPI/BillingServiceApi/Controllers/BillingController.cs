using BillingServiceApi.Billings.Classes;
using BillingServiceApi.Billings.Services;
using Microsoft.AspNetCore.Mvc;

namespace BillingServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillingController : ControllerBase
    {
        private readonly BillingService _billingService;

        public BillingController(
            BillingService billingService
        )
        {
            _billingService = billingService;
        }

        [HttpPost(Name = "ProcessOrder")]
        [ProducesResponseType(typeof(SuccessResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<object>> ProcessOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                var errorMessage = errors.FirstOrDefault()?.ErrorMessage;

                return BadRequest(CreateErrorResponse(StatusCodes.Status400BadRequest, "Invalid request data"));
            }

            var result = await _billingService.ProcessOrder(order);
            if (!result.Success)
            {
                return BadRequest(CreateErrorResponse(StatusCodes.Status500InternalServerError, "Error occured during order processing"));
            }

            return Ok(new SuccessResponse(result.Receipt));
        }

        private ErrorResponse CreateErrorResponse(int errorCode, string errorMessage)
        {
            return new ErrorResponse
            {
                ErrorCode = errorCode,
                ErrorMessage = errorMessage
            };
        }
    }
}
