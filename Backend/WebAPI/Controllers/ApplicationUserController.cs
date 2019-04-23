﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
          private UserManager<ApplicationUser> _userManager;
          private SignInManager<ApplicationUser> _signInManager;

          public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
          {
              _userManager = userManager;
              _signInManager = signInManager;
          }

          [HttpPost]
          [Route("Register")]
          public async Task<Object> PostApplicationUser(ApplicationUserModel model)
          {
              var applicationUser = new ApplicationUser()
              {
                  UserName = model.UserName,
                  Email = model.Email,
                  FullName = model.FullName
              };
              try
              {
                  //password pass in here becuse to do encription process
                  var result = await _userManager.CreateAsync(applicationUser, model.Password);
                  return Ok(result);
              }
              catch (Exception ex)
              {

                  throw ex;
              }
          }
    }
}