using Betting.Entities.Models;
using System.Collections.Generic;

namespace Betting.Data.DataModels.BrandX
{
    public interface IAspNetUserDataModel
    {
        AspNetUsers Get(string email);

        List<AspNetUsers> GetClients();
    }
}