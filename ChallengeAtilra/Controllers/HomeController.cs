using ChallengeAtilra.Models;
using CORE.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChallengeAtilra.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDataProviderServices _dataProviderServices;

    public HomeController(ILogger<HomeController> logger,
                          IDataProviderServices dataProviderServices)
    {
        _logger = logger;
        _dataProviderServices = dataProviderServices;
    }

    [HttpGet]
    public IActionResult Index()
    {
        _logger.LogInformation($"Getting view {nameof(Index)}");
        return View();
    }

    [HttpGet]
    public async Task<ActionResult> Queries(string target, string? parameters = null)
    {
        try
        {
            _logger.LogInformation($"Getting data from {nameof(Queries)}(string target)");
            if (!string.IsNullOrEmpty(target))
            {
                var result = await _dataProviderServices.GetDataTableFromTargetAsync(target, parameters);
                return PartialView("_partialQuery", result);
            }
        }
        catch (Exception)
        {
            return RedirectToAction("Error");
        }
        return View();
    }

    [HttpGet]
    public async Task<ActionResult> Registration(string target, string? parameters = null)
    {
        try
        {
            _logger.LogInformation($"Getting data from {nameof(Registration)}(string target)");
            if (!string.IsNullOrEmpty(target))
            {
                //var result = await _dataCommandServices.GetResultFromTargetAsync(target, parameters);
                //return PartialView("_partialQuery", result);
                return View();
            }
        }
        catch (Exception)
        {
            return RedirectToAction("Error");
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return PartialView(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}