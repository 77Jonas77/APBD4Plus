using APBD6.DTOs;
using APBD6.Repositories;

namespace APBD6.Services;

public class WarehouseService(IWarehouseRepository warehouseRepository) : IWarehouseService
{
    private IWarehouseRepository _warehouseRepository = warehouseRepository;

    public async Task<int> FullfillOrderAsync(ProductFullfillOrderData productFullfillOrderData)
    {
        //logika biz tutaj?
        if (productFullfillOrderData.Amount <= 0)
        {
            throw new ArgumentException("Amount <= 0");
        }

        return await warehouseRepository.FullfillOrderAsync(productFullfillOrderData);
    }
}