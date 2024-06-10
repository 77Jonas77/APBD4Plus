using APBD_Projekt.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Projekt.Services;

public interface IClientService
{
    public Task<bool> DoesPeselAlreadyExistAsync(string pesel);
    public Task<bool> DoesKrsAlreadyExistAsync(string krs);
    public Task<int> AddClientAsPhysicalAsync(CreateClientAsPhysicalRequestDto clientData);
    public Task<int> AddClientAsCompanyAsync(CreateClientAsCompanyRequestDto clientData);
    public Task RemovePhysicalClientWithIdAsync(int clientId);
    public Task<int> UpdatePhysicalClientDataWithIdAsync(UpdatePhysicalClientRequestDto clientId);
    public Task<int> UpdateCompanyClientDataWithIdAsync(UpdateCompanyClientRequestDto clientId);
}