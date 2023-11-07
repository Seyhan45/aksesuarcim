using Microsoft.AspNetCore.Mvc;

namespace aksesuarcim.ViewComponents
{
	public class RelatedList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
