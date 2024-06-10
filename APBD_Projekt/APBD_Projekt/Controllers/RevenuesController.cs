using APBD_Projekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Projekt.Controllers;

public class RevenuesController(IRevenueService contractService) : ControllerBase
{
}