using APBD_Projekt.DTOs;

namespace APBD_Projekt.Services;

public class ClientService : IClientService
{
    public Task<string?>? DoesPeselAlreadyExistAsync(string pesel)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DoesKrsAlreadyExistAsync(string krs)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddClientAsPhysicalAsync(CreateClientAsPhysicalRequestDto clientData)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddClientAsCompanyAsync(CreateClientAsCompanyRequestDto clientData)
    {
        throw new NotImplementedException();
    }

    public Task RemovePhysicalClientWithIdAsync(int clientId)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdatePhysicalClientDataWithIdAsync(UpdatePhysicalClientRequestDto clientId)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateCompanyClientDataWithIdAsync(UpdateCompanyClientRequestDto clientId)
    {
        throw new NotImplementedException();
    }

    Task<bool> IClientService.DoesPeselAlreadyExistAsync(string pesel)
    {
        throw new NotImplementedException();
    }
}