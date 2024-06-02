using Cw10.Context;
using Cw10.DTOs;
using Cw10.Models;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Services;

public class ShopService(ShopDbContext dbContext) : IShopService
{
    public async Task<GetAccountDataResponse?>? GetAccountByIdAsync(int id)
    {
        if (dbContext.Accounts != null)
        {
            var account = await (dbContext.Accounts)
                .Include(acc => acc.Role)
                .Include(acc => acc.ShoppingCarts)
                .ThenInclude(cart => cart.Product).Include(account => account.Role).Include(account => account.Role)
                .Include(account => account.Role).Include(account => account.Role).Include(account => account.Role)
                .FirstOrDefaultAsync(acc => acc.PkAccount == id);

            if (account == null)
                return null;

            return new GetAccountDataResponse
            {
                FirstName = account!.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                Phone = account.Phone,
                Role = account.Role.Name,
                Cart = account.ShoppingCarts.Select(cart => new ShoppingCartDetails
                {
                    ProductId = cart.FkProduct,
                    ProductName = cart.Product.Name,
                    Amount = cart.Amount
                }).ToList()
            };
        }

        throw new Exception("NotFound!");
    }


    public async Task<int> CreateProductWithCategoriesAsync(CreateProductRequest createProductRequest)
    {
        var newProduct = new Product
        {
            Name = createProductRequest.ProductName,
            Weight = createProductRequest.ProductWeight,
            Width = createProductRequest.ProductWidth,
            Height = createProductRequest.ProductHeight,
            Depth = createProductRequest.ProductDepth
        };
        dbContext.Products!.Add(newProduct);
        await dbContext.SaveChangesAsync();

        foreach (var categoryId in createProductRequest.ProductCategories)
        {
            var productCategory = new ProductCategory
            {
                FkProduct = newProduct.PkProduct,
                FkCategory = categoryId
            };
            dbContext.ProductsCategories!.Add(productCategory);
            await dbContext.SaveChangesAsync();
        }

        return newProduct.PkProduct;
    }

    public async Task<bool> DoesCategoryExist(int categoryId)
    {
        return await dbContext.Categories!.AnyAsync(c => c.PkCategory == categoryId);
    }
}