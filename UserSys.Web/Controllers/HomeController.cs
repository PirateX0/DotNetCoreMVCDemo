using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSys.Web.Models;
using UserSys.IServices;
using System.IO;
using UserSys.Web.Commons;
using System.Drawing;

namespace UserSys.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userService;
        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult CreateCaptCha()
        {
            Random rand = new Random();
            string code = rand.Next(1000, 9999).ToString();
            TempData["CaptCha"] = code;

            //.net core 2.0的System.Drawing只有几个简单的类，不全面
            //还要 https://www.nuget.org/packages/CoreCompat.System.Drawing.v2
            Stream picStream = ImageFactory.BuildImage(code, 50, 100, 20, 10);
            return File(picStream, "image/png");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequest model)
        {
            string code = (string)TempData["CaptCha"];
            if (code != model.Captcha)
            {
                return Json(new JsonData { Status = "error", Msg = "验证码错误" });
            }
            bool isOK = userService.CheckLogin(model.PhoneNum, model.Password);
            if(isOK)
            {
                return Json(new JsonData { Status = "ok",Msg="登陆成功" });
            }
            else
            {
                return Json(new JsonData { Status = "error",Msg="手机号或者密码错误"});
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterRequest model)
        {
            string code = (string)TempData["CaptCha"];
            if (code != model.Captcha)
            {
                return Json(new JsonData { Status = "error", Msg = "验证码错误" });
            }
            if (userService.GetByPhoneNum(model.PhoneNum) != null)
            {
                return Json(new JsonData { Status = "error", Msg = "手机号已经存在" });
            }
            userService.AddNew(model.PhoneNum, model.Password);
            return Json(new JsonData { Status = "ok" });
        }
    }
}
