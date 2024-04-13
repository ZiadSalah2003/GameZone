using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.ViewModels
{
    public class CreateGameFormViewModel
    {
        public string Name { get; set; } = string.Empty;
        [Display(Name="Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        public List<int> SelectedDevies { get; set; } = new List<int>();

        public IEnumerable<SelectListItem> Devies { get; set; } = Enumerable.Empty<SelectListItem>();

        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;

        public IFormFile Cover { get; set; } = default!;

    }
}
