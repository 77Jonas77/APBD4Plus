using APBD6.DTOs;

namespace APBD6.Repositories;

public interface IWarehouseRepository
{
    Task<int> FullfillOrderAsync(ProductFullfillOrderData productFullfillOrderData);
}