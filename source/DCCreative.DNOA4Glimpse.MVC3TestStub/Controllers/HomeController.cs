using System;
using System.Web.Mvc;

namespace DCCreative.DNOA4Glimpse.MVC3TestStub.Controllers {
	public class HomeController : Controller {
		public ActionResult Index() {
			Response.AppendHeader("X-XRDS-Location", new Uri(Request.Url, Response.ApplyAppPathModifier("~/Home/xrds")).AbsoluteUri);
			return View("Index");
		}

		public ActionResult Xrds() {
			return View("Xrds");
		}
	}
}
