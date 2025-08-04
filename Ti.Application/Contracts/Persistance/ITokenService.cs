using Ti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ti.Application.Contracts.Persistance
{
    public interface ITokenService
    {
        Task<string> GenerateToken(Guid userId, string username, string role, CancellationToken cancellationToken = default);
        //ClaimsPrincipal? ValidateToken(string token);
    }
}