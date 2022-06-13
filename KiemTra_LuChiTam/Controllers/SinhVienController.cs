using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_LuChiTam.Models;

namespace KiemTra_LuChiTam.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        DataDataContext data = new DataDataContext();
        public ActionResult Index()
        {
            var all_sinhvien = from tt in data.SinhViens select tt;
            return View(all_sinhvien);
        }

        public ActionResult Details(int id)
        {
            var D_sinhvien = data.SinhViens.Where(m => Convert.ToInt32(m.MaSV) == id).First();
            return View(D_sinhvien);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien sv)
        {
            var E_masv = collection["masv"];
            var E_hoten = collection["hoten"];
            var E_gioitinh = collection["gioitinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["ngaysinh"]);
            var E_hinh = collection["hinh"];
            var E_manganh = collection["manganh"];
            if (string.IsNullOrEmpty(E_masv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sv.MaSV = E_masv;
                sv.HoTen = E_hoten.ToString();
                sv.GioiTinh = E_gioitinh;
                sv.NgaySinh = E_ngaysinh;
                sv.Hinh = E_hinh.ToString();
                sv.MaNganh = E_manganh;
                data.SinhViens.InsertOnSubmit(sv);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }

        public ActionResult Edit(int id)
        {
            var E_sinhvien = data.SinhViens.First(m => Convert.ToInt32(m.MaSV) == id);
            return View(E_sinhvien);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_sinhvien = data.SinhViens.First(m => Convert.ToInt32(m.MaSV) == id);
            var E_hoten = collection["hoten"];
            var E_gioitinh = collection["gioitinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["ngaysinh"]);
            var E_hinh = collection["hinh"];
            var E_manganh = collection["manganh"];
            E_sinhvien.MaSV = id.ToString();

            if (string.IsNullOrEmpty(E_hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sinhvien.HoTen = E_hoten;
                E_sinhvien.GioiTinh = E_gioitinh;
                E_sinhvien.NgaySinh = E_ngaysinh;
                E_sinhvien.Hinh = E_hinh;
                E_sinhvien.MaNganh = E_manganh;
                UpdateModel(E_sinhvien);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }

        public ActionResult Delete(int id)
        {
            var D_sinhvien = data.SinhViens.First(m => Convert.ToInt32(m.MaSV) == id);
            return View(D_sinhvien);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_sinhvien = data.SinhViens.Where(m => Convert.ToInt32(m.MaSV) == id).First();
            data.SinhViens.DeleteOnSubmit(D_sinhvien);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}