using Proiect_O_A.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> RegisterUserAdminAsync(RegisterUserDTO dto);
        Task<bool> RegisterUserUserAsync(RegisterUserDTO dto);
        Task<bool> RegisterUserBucatarAsync(RegisterUserDTO dto);
        Task<bool> RegisterUserResponsabilMagAsync(RegisterUserDTO dto);
        Task<string> LoginUser(LoginUserDTO dto);
    }
}
