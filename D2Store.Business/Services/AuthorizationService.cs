using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Store.Business.Services
{
    public class AuthorizationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IClientRepository _clientRepository;

    }
}
