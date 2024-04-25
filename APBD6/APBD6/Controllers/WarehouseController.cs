using APBD6.DTOs;
using APBD6.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD6.Controllers;

[Route("/warehouse")]
[ApiController]
public class WarehouseController(IWarehouseService warehouseService) : ControllerBase
{
    private IWarehouseService _warehouseService = warehouseService;


    [HttpPost]
    public async Task<IActionResult> FullfillOrderAsync([FromBody] ProductFullfillOrderData productFullfillOrderData)
    {
        var keyId = await _warehouseService.FullfillOrderAsync(productFullfillOrderData);
        return Ok(keyId);
    }
}