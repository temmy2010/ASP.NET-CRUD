using WalletPlus_Inc.Web.Data.Entities;

namespace WalletPlus_Inc.Web.Data.Repositories.Interfaces
{
    public interface ICustomerRepository
    {

        Task<IEnumerable<Customer>> Get(string filter);
        Task<Customer> Get(Guid id);
        Task<Guid> Add(Customer customer);
        Task Update(Customer customer);
        Task Delete(Guid id);
    }
}
