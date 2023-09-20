using BLL.Interface;
using BLL.Model;
using DAL.Data;
using DAL.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AccountService:IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;   //userManager => context 
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<bool> SignUp(SignUpModel signUpModel)
        {
            var createdUser =await SaveUser(signUpModel);
            if (createdUser == null) return false;
            return true;
    
        }

        public async Task<UserModel> LoginAsync(SignInModel signInModel)
        {
            var result= await _signInManager.PasswordSignInAsync(signInModel.UserName, signInModel.Password,false,false);
            

            if (!result.Succeeded)
            {
                return null;
            }
            var user = await _userManager.FindByNameAsync(signInModel.UserName);
            var roles = await _userManager.GetRolesAsync(user);
            var id = user.Id;
            var token = generateToken(signInModel.UserName);
            var _token = new JwtSecurityTokenHandler().WriteToken(token);
            var exp = token.ValidTo.Date;

            return new UserModel() { Id = id, Name = signInModel.UserName, Role = roles[0], _token = _token, _tokenExpirationDate = exp};
        }
         
        private JwtSecurityToken generateToken(string UserName)
        {
            var tokenDetails = new string[2];
            var authClaims = new List<Claim>
            {
                new Claim("id", "12345"),
                new Claim(ClaimTypes.Name, UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };


            var authSignKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudiences"],
                expires: DateTime.Now.AddDays(2),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignKey, SecurityAlgorithms.HmacSha256Signature));

            /*tokenDetails[0] = new JwtSecurityTokenHandler().WriteToken(token);
            var a = token.ValidTo;*/
            return token;
        }


        public async Task<User> SaveUser(SignUpModel signUp)
        {
            var user = new User()
            {
                UserName = signUp.UserName,
                PhoneNumber = signUp.Phone,
            };

            if (signUp.Role != Role.Manager && signUp.Role != Role.DeliveryPersons)
                return null;
                        var result = await _userManager.CreateAsync(user, signUp.Password);

            if (result.Succeeded)
            {
                var createdUser = await _userManager.FindByNameAsync(signUp.UserName);
                if (createdUser != null) 
                {
                    await _userManager.AddToRoleAsync(createdUser, signUp.Role);
                    return createdUser;
                }
                return null;
            }
            else return null;
        }

        public async Task<UserDataModel> FindUserById(string id)
        {
            var user=await _userManager.FindByIdAsync(id);
            if(user == null)
                return null;
            var role = await _userManager.GetRolesAsync(user);
            var userModel = new UserDataModel()
            {
                Id = user.Id,
                Name = user.UserName,
                Phone = user.PhoneNumber,
                Role = role[0]
            };
            return userModel;
        }
    }
}
