﻿
namespace GameZone.Controllers
{
	public class GamesController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly ICategoriesService _categoriesService;
		private readonly IDevicesService _devicesService;

		public GamesController(ApplicationDbContext context, ICategoriesService categoriesService, IDevicesService devicesService)
		{
			_context = context;
			this._categoriesService = categoriesService;
			_devicesService = devicesService;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Create()
		{
			CreateGameFormViewModel viewModel = new()
			{
				Categories = _categoriesService.GetSelectList(),
				Devices = _devicesService.GetSelectList()
			};
			return View(viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(CreateGameFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Categories = _categoriesService.GetSelectList();
				model.Devices = _devicesService.GetSelectList();
				return View(model);
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
