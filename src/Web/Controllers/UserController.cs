﻿using Microsoft.AspNetCore.Mvc;
using MovieCatalog.Application.Exceptions;
using MovieCatalog.Application.Users;
using MovieCatalog.Application.Users.Dtos;

namespace MovieCatalog.Web.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegistrationDto model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await _userService.Register(model);
        }
        catch (IdentityErrorException e)
        {
            foreach (var error in e.Errors)
                ModelState.AddModelError(error.Code.Contains("Password") ? "Password" : "", error.Description);
            return View(model);
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", "Регистрация не успешна.");
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await _userService.Login(model);
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
            return View(model);
        }
        
        return RedirectToAction("Index", "Home");;
    }

    public async Task<IActionResult> Logout()
    {
        await _userService.Logout();
        
        return RedirectToAction("Index", "Home");
    }
}