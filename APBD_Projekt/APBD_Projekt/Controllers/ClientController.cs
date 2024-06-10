using APBD_Projekt.DTOs;
using APBD_Projekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Projekt.Controllers;

[ApiController]
[Route("clients/")]
public class ClientController(IClientService clientService) : ControllerBase
{
    [HttpPost("/add/physical")]
    public async Task<IActionResult> AddClientAsPhysicalAsync(CreateClientAsPhysicalRequestDto clientData)
    {
        return Ok();
    }

    [HttpPost("/add/company")]
    public async Task<IActionResult> AddClientAsCompanyAsync(CreateClientAsCompanyRequestDto clientData)
    {
        return Ok();
    }

    [HttpDelete("/delete/physical/{clientId:int}")]
    public async Task<IActionResult> RemovePhysicalClientWithIdAsync(int clientId)
    {
        return Ok();
    }

    [HttpPut("/update/physical")]
    public async Task<IActionResult> UpdatePhysicalClientDataWithIdAsync(UpdatePhysicalClientRequestDto clientData)
    {
        return Ok();
    }

    [HttpPut("/update/company")]
    public async Task<IActionResult> UpdatePhysicalClientDataWithIdAsync(UpdateCompanyClientRequestDto clientData)
    {
        return Ok();
    }
}