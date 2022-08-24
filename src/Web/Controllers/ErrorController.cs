﻿using Microsoft.AspNetCore.Mvc;

namespace MovieCatalog.Web.Controllers;

public class ErrorController : Controller
{
    [Route("[controller]/403")]
    public IActionResult Error403() => View();

    [Route("[controller]/404")]
    public IActionResult Error404() => View();

    public IActionResult Index() => View();
}