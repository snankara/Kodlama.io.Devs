using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nest;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        private readonly BaseDbContext _context;
        public UserRepository(BaseDbContext context) : base(context)
        {
            _context = context;
        }

        public IList<OperationClaim> GetClaims(User user)
        {
            using (var dbContext = _context)
            {
                var result = from operationClaim in dbContext.OperationClaims
                             join userOperationClaim in dbContext.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
