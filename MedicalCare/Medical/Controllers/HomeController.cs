using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medical.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //Action nhiệm vụ xử lý yêu cầu => trả về kết quả cho người dùng
        //Kết quả có nhiều kiểu: VIew html, data json xml ,file
        public ActionResult TrangChu()
        {
            return View();
        }
    }
}