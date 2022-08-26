using JWT_UsingDatabase.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWT_UsingDatabase.Services
{
    public class JWTManagerRepo : IJWTManagerRepo
    {


        private UsersDbContext usersDbContext;
        private IConfiguration configuration;
     
        public JWTManagerRepo(IConfiguration configuration, UsersDbContext usersDbContext)
        {
            this.configuration = configuration;

            this.usersDbContext = usersDbContext;
        }


        public Tokens Authenticate(Users user)
        {
            if(usersDbContext.User.Any(model=>model.Username!=user.Username && model.Password!=user.Password))
            {
                return null;
            }
            else
            {
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(
                        new Claim[] { new Claim(ClaimTypes.Name, user.Username) }

                        ),

                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
                };

                //creating token
                var token = tokenhandler.CreateToken(tokenDescriptor);

                return new Tokens { Token = tokenhandler.WriteToken(token) };
            }
        }
    }
}
