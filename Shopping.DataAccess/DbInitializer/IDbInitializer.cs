using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataAccess.DbInitializer
{
    public interface IDbInitializer
    {
        //helps us to create admin user and the other roles
        void Initialize();  
    }
}
