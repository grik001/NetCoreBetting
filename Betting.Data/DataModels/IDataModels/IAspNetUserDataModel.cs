using Betting.Entities.Models;

namespace Betting.Data.DataModels.BrandX
{
    public interface IAspNetUserDataModel
    {
        AspNetUsers Get(string email);
    }
}