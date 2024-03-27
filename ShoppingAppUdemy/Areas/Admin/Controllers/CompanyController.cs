using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.DataAccess.Repository.IRepository;
using Shopping.Models;
using Shopping.Models.ViewModels;
using Shopping.Utility;
using System.Data;

namespace ShoppingAppUdemy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        
            private readonly IUnitOfWork _unitOfWork;
            public CompanyController(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;


            }

            public IActionResult Index()
            {
                List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
           
                return View(objCompanyList);
            }

            public IActionResult Upsert(int? id)
            {
            //IEnumerable<SelectListItem> CategoryList = 

            //ViewBag = CategoryList = CategoryList;
            // ViewData["CategoryList"] = CategoryList;
    
            if(id == null || id == 0)
            {
                return View(new Company());
            }
            else
            {
                Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);  
                return View(companyObj);
            }

            
            }

            [HttpPost]
            public IActionResult Upsert(Company CompanyObj)
            {         
              
                if (ModelState.IsValid)
                {
                

                if (CompanyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(CompanyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(CompanyObj);
                }

                   // _unitOfWork.Company.Add(CompanyVM.Company);
                    _unitOfWork.Save();
                    TempData["success"] = "Company is Created successfully";
                    return RedirectToAction("Index");
            }
            else
            {
              

              return View(CompanyObj);
            }

            }

            //Edit
           /* public IActionResult Edit(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                Company? CompanyFromDb = _unitOfWork.Company.Get(u => u.Id == id);
                //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
                //Category? categoryFromDb2 = _db.Categories.Where(u => u.Id==id).FirstOrDefault();

                if (CompanyFromDb == null)
                {
                    return NotFound();
                }
                return View(CompanyFromDb);
            }
            [HttpPost]
            public IActionResult Edit(Company obj)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Company.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Category is Edited successfully";
                    return RedirectToAction("Index");
                }

                return View();
            }*/

            //Delete - GET Action
          /*  public IActionResult Delete(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
            Company? CompanyFromDb = _unitOfWork.Company.Get(u => u.Id == id);


                if (CompanyFromDb == null)
                {
                    return NotFound();
                }
                return View(CompanyFromDb);
            }
            [HttpPost, ActionName("Delete")] //Delete POST ACTION
            public IActionResult DeletePOST(int? id)
            {
            Company? obj = _unitOfWork.Company.Get(u => u.Id == id);
                if (obj == null)
                {
                    return NotFound();
                }
                _unitOfWork.Company.Remove(obj);
                _unitOfWork.Save();
                TempData["success"] = "Company is Deleted successfully";
                return RedirectToAction("Index");

            }*/
        #region
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });    
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if (CompanyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });

            }         

            _unitOfWork.Company.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }


        #endregion
    }
}
