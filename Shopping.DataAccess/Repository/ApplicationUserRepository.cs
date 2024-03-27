using Shopping.DataAccess.Data;
using Shopping.DataAccess.Repository.IRepository;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        /*public void Save()
        {
            _db.SaveChanges();
        }*/

       /* public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }*/
    }
}
