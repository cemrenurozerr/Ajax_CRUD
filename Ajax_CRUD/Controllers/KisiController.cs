using Ajax_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ajax_CRUD.Controllers
{
	public class KisiController : Controller
	{
		private readonly KisiContext db;

		public KisiController(KisiContext db)
		{
			this.db = db;
		}

		public IActionResult Index()
		{
			List<Kisi> kisiler = db.Kisiler.ToList();
			return Json(kisiler);
		}
		public IActionResult GetKisi(int uid)
		{
			Kisi kisi = db.Kisiler.FirstOrDefault(x => x.ID == uid);
			var jsonkisi = JsonConvert.SerializeObject(kisi);
			return Json(jsonkisi);
		}
		[HttpPost]
		public IActionResult Ekle(Kisi kisi)
		{
			db.Kisiler.Add(kisi);
			db.SaveChanges();
			var jsonkisi = JsonConvert.SerializeObject(kisi);
			return Json(jsonkisi);
		}
		public IActionResult Sil(int id)
		{
			var kisi = db.Kisiler.FirstOrDefault(x => x.ID == id);
			db.Kisiler.Remove(kisi);
			db.SaveChanges();
			return Json(kisi);
		}
		[HttpPost]
		public IActionResult Guncelle(Kisi kisi)
		{
			Kisi secilen = db.Kisiler.FirstOrDefault(x => x.ID == kisi.ID);
			secilen.Ad = kisi.Ad;
			secilen.Soyad = kisi.Soyad;
			db.SaveChanges();
			var jsonkisi = JsonConvert.SerializeObject(kisi);
			return Json(jsonkisi);
		}
	}
}
