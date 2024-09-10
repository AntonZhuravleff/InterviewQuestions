using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.Services;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Pages.Tags
{
    public class IndexModel : PageModel
    {
        private readonly ITagsViewModelService _tagsViewModelService;

        public TagsViewModel TagsViewModel { get; set; }

        [BindProperty]
        public TagViewModel TagToAdd { get; set; }

        public IndexModel(ITagsViewModelService tagsViewModelService)
        {
            _tagsViewModelService = tagsViewModelService;
        }

        public async Task OnGet()
        {
            TagsViewModel = await _tagsViewModelService.GetTagsViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _tagsViewModelService.AddTag(TagToAdd);
                return RedirectToPage("Index");
            }

            TagsViewModel = await _tagsViewModelService.GetTagsViewModel();
            return Page();
        }

        public async Task<IActionResult> OnPostDelete(int tagId)
        {
            await _tagsViewModelService.DeleteTag(tagId);
            return RedirectToPage("/Tags/Index");
        }
    }
}
