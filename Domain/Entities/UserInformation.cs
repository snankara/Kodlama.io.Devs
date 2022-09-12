using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserInformation : Entity
    {
        public int UserId { get; set; }
        public string GithubAddress { get; set; }

        //Other fields

        public UserInformation(){}
        public UserInformation(int userId, string githubAddress)
        {
            UserId = userId;
            GithubAddress = githubAddress;
        }
    }
}
