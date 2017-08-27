using System.Linq;
using Betting.Entities.Models;
using Betting.Data.DataModels.BrandX;
using System.Collections.Generic;

namespace Betting.Data.DataModels
{
    public class AspNetUsersDataModel : IAspNetUserDataModel
    {
        public AspNetUsers Get(string email)
        {
            using (var context = new BrandxStoreContext())
            {
                return context.AspNetUsers.FirstOrDefault(x => x.Email == email);
            }
        }

        public List<AspNetUsers> GetClients()
        {
            using (var context = new BrandxStoreContext())
            {
                return context.AspNetUsers.Where(x => x.AspNetUserRoles.Any(r => r.Role.Name == "Client")).ToList();
            }
        }
    }
}
