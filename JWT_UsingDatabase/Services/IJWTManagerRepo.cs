using JWT_UsingDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_UsingDatabase.Services
{
    public interface IJWTManagerRepo
    {
        Tokens Authenticate(Users user);
    }
}
