﻿using MovieCatalog.Application.Users.Dtos;

namespace MovieCatalog.Application.Interfaces;

public interface IUserIdentityService
{
    public Task Register(RegistrationDto registrationDto, string uId);
    public Task Login(LoginDto loginDto);
    public Task Logout();
}