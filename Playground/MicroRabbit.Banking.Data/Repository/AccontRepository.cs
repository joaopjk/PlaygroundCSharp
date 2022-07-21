using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using System.Collections.Generic;

namespace MicroRabbit.Banking.Data.Repository
{
    public class AccontRepository : IAccountRepository
    {
        private readonly BankingDbContext dbContext;

        public AccontRepository(BankingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return dbContext.Accounts;
        }
    }
}
