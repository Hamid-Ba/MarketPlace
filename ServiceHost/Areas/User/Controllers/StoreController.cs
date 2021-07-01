﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Framework.Application.Authentication;
using MarketPlace.ApplicationContract.AI.Account;
using MarketPlace.ApplicationContract.AI.StoreAgg;
using MarketPlace.ApplicationContract.ViewModels.StoreAgg;
using MarketPlace.Query.Contract.Store;
using Microsoft.AspNetCore.Identity;

namespace ServiceHost.Areas.User.Controllers
{
    public class StoreController : UserBaseController
    {
        private readonly IStoreQuery _storeQuery;
        private readonly IUserApplication _userApplication;
        private readonly IStoreApplication _storeApplication;

        public StoreController(IStoreQuery storeQuery, IUserApplication userApplication, IStoreApplication storeApplication)
        {
            _storeQuery = storeQuery;
            _userApplication = userApplication;
            _storeApplication = storeApplication;
        }

        [HttpGet("Store-Requests")]
        public async Task<IActionResult> Index()
        {
            if (!await _userApplication.IsUserBlocked(User.GetUserId())) return View(await _storeQuery.GetUserStoresRequestsBy(User.GetUserId()));

            TempData[ErrorMessage] = "کاربر گرامی حساب شما مسدود شده است";
            return RedirectToAction("Dashboard", "Home", new { area = "User" });
        }

        [HttpGet("Send-Request")]
        public async Task<IActionResult> SendRequest()
        {
            if (!await _userApplication.IsUserBlocked(User.GetUserId())) return View();

            TempData[ErrorMessage] = "کاربر گرامی حساب شما مسدود شده است";
            return RedirectToAction("Dashboard", "Home", new { area = "User" });
        }

        [HttpPost("Send-Request"), ValidateAntiForgeryToken]
        public async Task<IActionResult> SendRequest(SendStoreRequestVM command)
        {
            if (!await _userApplication.IsUserBlocked(User.GetUserId()))
            {
                command.UserId = User.GetUserId();
                if (ModelState.IsValid)
                {
                    var result = await _storeApplication.SendRequest(command);

                    if (result.IsSucceeded)
                    {
                        TempData[SuccessMessage] = result.Message;
                        return RedirectToAction("Index", new { area = "User" });
                    }

                    TempData[ErrorMessage] = result.Message;
                }

                return View(command);
            }

            TempData[ErrorMessage] = "کاربر گرامی حساب شما مسدود شده است";
            return RedirectToAction("Dashboard", "Home", new { area = "User" });
        }
    }
}