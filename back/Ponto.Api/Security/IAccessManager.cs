using Ponto.Api.Dto;
using Ponto.Data.Identities;
using Ponto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ponto.Api.Security
{
    public interface IAccessManager
    {
        Task<bool> ValidarCredencial(ApplicationUser user);

        Task<Token> GerarToken(string username);
        
    }
}
