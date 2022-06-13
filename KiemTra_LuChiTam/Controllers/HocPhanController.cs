using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_LuChiTam.Models;

namespace KiemTra_LuChiTam.Controllers
{
    public class HocPhanController : Controller
    {
        // GET: HocPhan
        DataDataContext data = new DataDataContext();
        public ActionResult Index()
        {
            var all_hocphan = from tt in data.HocPhans select tt;
            return View(all_hocphan);
        }
    }
}