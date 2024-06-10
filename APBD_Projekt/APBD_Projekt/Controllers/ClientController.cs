using APBD_Projekt.DTOs;
using APBD_Projekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Projekt.Controllers;

[ApiController]
[Route("clients/")]
public class ClientController(IClientService clientService) : ControllerBase
{
    [HttpPost("/add")]
    public async Task<IActionResult> AddClientAsync(CreateClientRequestDto clientData)
    {
        return Ok();
    }

    [HttpDelete("/delete/{clientId:int}")]
    public async Task<IActionResult> RemoveClientWithIdAsync(int clientId)
    {
        return Ok();
    }

    [HttpPut("/update")]
    public async Task<IActionResult> UpdateClientDataWithIdAsync(CreateClientRequestDto clientData)
    {
        return Ok();
    }
}