using System.Data.Common;
using System.Data.SqlClient;
using APBD6.DTOs;

namespace APBD6.Repositories;

public class WarehouseRepository(IConfiguration configuration) : IWarehouseRepository
{
    private IConfiguration _configuration = configuration;

    public async Task<int> FullfillOrderAsync(ProductFullfillOrderData productFullfillOrderData)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:Default"]);
        await con.OpenAsync();

        // #1a Checking ID Product exists 
        // ? Should I use count(*) instead ?
        if (!await IsProductWithIdValidAsync(con, productFullfillOrderData.IdProduct))
        {
            throw new ArgumentException($"Product with id: {productFullfillOrderData.IdProduct} does not exists");
        }

        // #1b Checking ID warehouse exists
        // ? Should I use count(*) instead ?
        if (!await IsWarehouseWithIdValidAsync(con, productFullfillOrderData.IdWarehouse))
        {
            throw new ArgumentException($"Warehouse with id: {productFullfillOrderData.IdWarehouse} does not exists");
        }

        int orderId;
        // #2a + 3a Checking order's data 
        ;
        if ((orderId = (int)(await GetValidOrderMatchingAsync(con, productFullfillOrderData.IdProduct,
                productFullfillOrderData.Amount,
                productFullfillOrderData.CreatedAt))!) != -1)
        {
            throw new ArgumentException(
                $"Order with given data ID: {productFullfillOrderData.IdProduct}, AMOUNT: {productFullfillOrderData.Amount} does not exists!");
        }

        // #3b
        if (await IsOrderInWarehouseAsync(con, orderId))
        {
            throw new ArgumentException($"Order with given id: {orderId} is already fulfilled");
        }

        // #4 transaction
        var transaction = await con.BeginTransactionAsync();
        await UpdateFullfilledAtAsync(con, transaction, orderId);
        var id = await InsertNewRecordIntoProductWarehouse(con, transaction, productFullfillOrderData, orderId);
        await transaction.RollbackAsync();
        //await transaction.CommitAsync();
        return (int)id;
    }

    private async Task<int> InsertNewRecordIntoProductWarehouse(SqlConnection con, DbTransaction transaction, ProductFullfillOrderData productFullfillOrderData, int orderId)
    {
        throw new NotImplementedException();
    }

    private async Task UpdateFullfilledAtAsync(SqlConnection con, DbTransaction transaction, int orderId)
    {
        throw new NotImplementedException();
    }

    private async Task<bool> IsOrderInWarehouseAsync(SqlConnection con, int idOrder)
    {
        await using var cmd = new SqlCommand();
        cmd.CommandText = "SELECT COUNT(*) FROM Product_Warehouse WHERE IdOrder = @IdOrder;";
        cmd.Parameters.AddWithValue("@IdOrder", idOrder); // as a reminder :)
        cmd.Connection = con;

        var fulfilledIdOrderCount = (int?)await cmd.ExecuteScalarAsync();

        return fulfilledIdOrderCount != 0;
    }

    private async Task<int?> GetValidOrderMatchingAsync(SqlConnection con, int idProduct, int amount,
        DateTime createdAt)
    {
        await using var cmd = new SqlCommand();
        cmd.CommandText =
            $"SELECT IdOrder FROM [Order] WHERE IdProduct = {idProduct} AND Amount = {amount} AND CreatedAt < {createdAt} AND FulfilledAt IS NULL";
        cmd.Connection = con;

        var orderResId = (int?)(await cmd.ExecuteScalarAsync() ?? -1);

        return orderResId;
    }

    private async Task<bool> IsWarehouseWithIdValidAsync(SqlConnection con, int id)
    {
        await using var cmd = new SqlCommand();
        cmd.CommandText = $"SELECT IdWarehouse FROM Warehouse WHERE IdWarehouse= {id}";
        cmd.Connection = con;

        var warehouseRes = (int?)(await cmd.ExecuteScalarAsync() ?? -1);

        return warehouseRes != -1;
    }

    private async Task<bool> IsProductWithIdValidAsync(SqlConnection con, int id)
    {
        await using var cmd = new SqlCommand();
        cmd.CommandText = $"SELECT IdProduct FROM Product WHERE IdProduct = {id}";
        cmd.Connection = con;

        var productRes = (int?)(await cmd.ExecuteScalarAsync() ?? -1);

        return productRes != -1;
    }
}