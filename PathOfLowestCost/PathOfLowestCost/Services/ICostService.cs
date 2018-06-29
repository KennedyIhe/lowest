using System.Threading.Tasks;
using PathOfLowestCost.Models;

namespace PathOfLowestCost.Services
{
    public interface ICostService
    {
        Task<ResultItem> GetLowest(string mData);
    }
}