using Medical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medical.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangXuat()
        {
            
            Session.Clear();
            return RedirectToAction("TrangChu", "Home");
        }


        [HttpPost]
        public ActionResult DangNhap(string username, string password)
        {
            //1. Ktra tk vs mk có trống => trở về trang login thông báo lỗi
            if (string.IsNullOrEmpty(username) == true | string.IsNullOrEmpty(password) == true)
            {
                ViewBag.message = "Tài khoản và mật khẩu không được để trống!!!";
                return View();
            }
            //2. tìm tk theo tên đăg nhập trong db
            var tk = new Login().ChiTiet(username);
            //3. kt xem có tồn tại tk k => nếu null => báo lỗi
            if (tk == null)
            {
                ViewBag.message = "Tài khoản hoặc mật khẩu không đúng!!!";
                ViewBag.username = username;
                return View();
            }
            //4. Kiểm tra mk nếu sai => về trang đăng nhập hiển thị lỗi 
            if (tk.Password != password)
            {
                ViewBag.message = "Tài khoản hoặc mật khẩu không đúng!!!";
                ViewBag.username = username;
                return View();
            }
            //5. Kiem tra active
            /*
                        if (tk.Active != true)
                        {
                            ViewBag.message = "Tài khoản đang tạm khóa!!!";
                            ViewBag.username = username;
                            return View();
                        }*/
            //Lưu lại sesstion
            Session["user"] = tk;

            //6. chuyển hướng sang trang chủ
            return RedirectToAction("TrangChu", "Home");
        }


    }
}