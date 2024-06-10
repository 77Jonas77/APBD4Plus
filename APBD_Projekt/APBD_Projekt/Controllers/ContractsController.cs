using APBD_Projekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Projekt.Controllers;

[ApiController]
[Route("contracts/")]
public class ContractsController(IContractService contractService) : ControllerBase
{
    [HttpPost("/add")]
    public async Task<IActionResult> AddContractAsync()
    {
        return Ok();
    }

    [HttpPost("/add/payment")]
    public async Task<IActionResult> AddPaymentForContractAsync()
    {
        return Ok();
    }
}