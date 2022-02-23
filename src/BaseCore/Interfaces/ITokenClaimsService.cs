using System.Threading.Tasks;

namespace LonShop.BaseCore.Interfaces
{
    public interface ITokenClaimsService
    {
        Task<string> GetTokenAsync(string userName);
    }
}