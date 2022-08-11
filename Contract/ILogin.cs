using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminDiplomacyAPP.Entities;

namespace AdminDiplomacyAPP.Contract
{
    public interface ILogin
    {
        Task<loginModel> GetUser(string Username,string Password);
    }
}
