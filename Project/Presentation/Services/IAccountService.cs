using System.Collections.Generic;
using ApplicationCore.DTO;
using ApplicationCore.Entities;

namespace Presentation.Services
{
    public interface IAccountService
    {
        Account GetAccount(string id);
        IEnumerable<AccountDTO> GetAccounts(int pageIndex, int pageSize, out int count);
        //IEnumerable<AccountDTO> GetAllRole();
        void CreateAccount(Account Account); // them moi bac si
        void UpdateAccount(Account Account);
        void DeleteAccount(string id);
    }
}