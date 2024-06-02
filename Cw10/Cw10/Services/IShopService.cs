using Cw10.DTOs;

namespace Cw10.Services;

public interface IShopService
{
    Task<GetAccountDataResponse?>? GetAccountByIdAsync(int id);
    Task<int>? CreateProductWithCategoriesAsync(CreateProductRequest createProductRequest);
    Task<bool> DoesCategoryExist(int categoryId);
}