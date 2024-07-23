using Microsoft.AspNetCore.Mvc;

namespace RentACar_WebMvcUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}


