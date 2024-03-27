using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingRazorApp_Temp.Data;
using ShoppingRazorApp_Temp.Models;

namespace ShoppingRazorApp_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if(id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category is Updated successfully";
                return RedirectToAction("Index");
            }

            return Page();
        }
    }
}
