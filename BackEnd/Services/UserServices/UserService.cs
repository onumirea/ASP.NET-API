using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Proiect_O_A.Entities;
using Proiect_O_A.Entities.DTOs;
using Proiect_O_A.Model.Constants;
using Proiect_O_A.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_O_A.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepositoryWrapper _repository;

        public UserService(UserManager<User> userManager, IRepositoryWrapper repository)
        {
            _userManager = userManager;
            _repository = repository;
        }
        public async Task<string> LoginUser(LoginUserDTO dto)
        {
            User user = await _userManager.FindByEmailAsync(dto.Email);
            var eCorect = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (user != null && eCorect == PasswordVerificationResult.Success)
            {
                user = await _repository.User.GetUserByIdWithRoles(user.Id);

                List<string> roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();

                var newJti = Guid.NewGuid().ToString();

                var tokenHandler = new JwtSecurityTokenHandler();
                var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom secret key for auth"));

                var token = GenerateJwtToken(signinkey, user, roles, tokenHandler, newJti);

                _repository.SessionToken.Create(new SessionToken(newJti, user.Id, token.ValidTo));
                await _repository.SessionToken.SaveAsync();

                return tokenHandler.WriteToken(token);
            }
            return "";
        }
        private SecurityToken GenerateJwtToken(SymmetricSecurityKey signinKey, User user, List<string> roles, JwtSecurityTokenHandler tokenHandler, string jti)
        {
            var subject = new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Nume + " " + user.Prenume),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, jti)
            });

            foreach (var role in roles)
            {
                subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }
        public async Task<bool> RegisterUserAdminAsync(RegisterUserDTO dto)
        {
            var registerUser = new User();

            registerUser.UserName = dto.Nume + dto.Prenume;
            registerUser.Email = dto.Email;
            registerUser.Nume = dto.Nume;
            registerUser.Prenume = dto.Prenume;

            var result = await _userManager.CreateAsync(registerUser, dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(registerUser, UserRoleType.Admin);

                return true;
            }

            return false;
        }
        public async Task<bool> RegisterUserUserAsync(RegisterUserDTO dto)
        {
            var registerUser = new User();

            registerUser.UserName = dto.Nume + dto.Prenume;
            registerUser.Email = dto.Email;
            registerUser.Nume = dto.Nume;
            registerUser.Prenume = dto.Prenume;

            var result = await _userManager.CreateAsync(registerUser, dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(registerUser, UserRoleType.User);

                return true;
            }

            return false;
        }
        public async Task<bool> RegisterUserBucatarAsync(RegisterUserDTO dto)
        {
            var registerUser = new User();

            registerUser.UserName = dto.Nume + dto.Prenume;
            registerUser.Email = dto.Email;
            registerUser.Nume = dto.Nume;
            registerUser.Prenume = dto.Prenume;

            var result = await _userManager.CreateAsync(registerUser, dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(registerUser, UserRoleType.Bucatar);

                return true;
            }

            return false;
        }
        public async Task<bool> RegisterUserResponsabilMagAsync(RegisterUserDTO dto)
        {
            var registerUser = new User();

            registerUser.UserName = dto.Nume + dto.Prenume;
            registerUser.Email = dto.Email;
            registerUser.Nume = dto.Nume;
            registerUser.Prenume = dto.Prenume;

            var result = await _userManager.CreateAsync(registerUser, dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(registerUser, UserRoleType.ResponsabilMag);

                return true;
            }

            return false;
        }
    }
}
