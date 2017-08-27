using System.Linq;
using Betting.Entities.Models;
using Betting.Data.DataModels.BrandX;

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
    }
}
