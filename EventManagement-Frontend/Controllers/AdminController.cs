﻿using EventManagement_Frontend.IService;
using EventManagement_Frontend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement_Frontend.Controllers
{
    public class AdminController : Controller
    {
        //[Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
