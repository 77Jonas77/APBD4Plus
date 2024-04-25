using APBD6.DTOs;

namespace APBD6.Services;

public interface IWarehouseService
{
    Task<int> FullfillOrderAsync(ProductFullfillOrderData productFullfillOrderData);
}