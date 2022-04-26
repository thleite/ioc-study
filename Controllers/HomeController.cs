using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ioc_container.Models;
using ioc_container.Services;

namespace ioc_container.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly OperationService _operationServiceOne;
    private readonly OperationService _operationServiceTwo;

    public HomeController(
        ILogger<HomeController> logger,
        OperationService operationServiceOne,
        OperationService operationServiceTwo)
    {
        _logger = logger;
        _operationServiceOne = operationServiceOne; 
        _operationServiceTwo = operationServiceTwo;
    }

    public string Index()
    {
        var result = $@"
        First Instance of Operation Service - {_operationServiceOne.Id} {Environment.NewLine}
        - Scoped Service Id : {_operationServiceOne.ScopedOperation.Id} {Environment.NewLine}
        - Transient Service Id : {_operationServiceOne.TransientOperation.Id} {Environment.NewLine}
        - Singleton Service Id : {_operationServiceOne.SingletonOperation.Id} {Environment.NewLine}
        - Singleton Instance Service Id : {_operationServiceOne.SingletonInstanceOperation.Id} {Environment.NewLine}
        {Environment.NewLine}
        Second Instance of Operation Service - {_operationServiceTwo.Id}
        - Scoped Service Id : {_operationServiceTwo.ScopedOperation.Id} {Environment.NewLine}
        - Transient Service Id : {_operationServiceTwo.TransientOperation.Id} {Environment.NewLine}
        - Singleton Service Id : {_operationServiceTwo.SingletonOperation.Id} {Environment.NewLine}
        - Singleton Instance Service Id : {_operationServiceTwo.SingletonInstanceOperation.Id} {Environment.NewLine}
        ";

        return result;
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
