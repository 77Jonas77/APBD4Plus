using Cw10.DTOs;
using Cw10.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw10.Controllers;

[Route("/api")]
[ApiController]
public class AccountsController(IShopService shopService) : ControllerBase
{
    [HttpGet("/accounts/{accountId:int}")]
    public async Task<IActionResult> GetAccountByIdAsync(int accountId)
    {
        try
        {
            var acc = await shopService.GetAccountByIdAsync(accountId)!;

            if (acc is null)
                return NotFound();

            return Ok(acc);
        }
        catch
        {
            return StatusCode(500, "Smth went wrong ;(");
        }
    }


    [HttpPost("/products")]
    public async Task<IActionResult> CreateProductWithCategoriesAsync(CreateProductRequest request)
    {
        try
        {
            foreach (var categoryId in request.ProductCategories)
            {
                var resp = await shopService.DoesCategoryExist(categoryId);
                if (!resp)
                {
                    return BadRequest("Invalid Category Id: " + categoryId);
                }
            }

            var respId = await shopService.CreateProductWithCategoriesAsync(request)!;
            if (respId < 0)
                return StatusCode(500, "Failed to create product.");

            return Created();
        }
        catch
        {
            return StatusCode(500, "Something went wrong!");
        }
    }
}