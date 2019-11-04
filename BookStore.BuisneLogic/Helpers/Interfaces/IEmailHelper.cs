using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Helpers.Interfaces
{
    public interface IEmailHelper
    {
        Task Send(string email, string message);
    }
}
