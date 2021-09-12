using MicroRabbit.Banking.Domain.Models;
using System.Collections.Generic;

namespace MicroRabbit.Banking.Domain.Interfaces
{
    interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
