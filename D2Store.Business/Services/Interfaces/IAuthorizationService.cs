using D2Store.Common.DTO.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Store.Business.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<bool> RegisterAsync(RegisterModel registerClient);

        Task<AuthorizationToken> LoginAsync(LoginModel loginModel);
    }
}
