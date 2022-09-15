using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.Models.DataObjects;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Data;
using StudentManagement.Services.Interfaces;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace StudentManagement.Services.Services
{
    public class UserService : IUser
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<UserDto> Register(UserDto request)
        {
            try
            {
                var data = await _context.Users.AnyAsync(user => user.RegNumber == request.RegNumber);
                if (data) return null;

                CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

                User newUser = new User
                {
                    RegNumber = request.RegNumber,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };

                await _context.Users.AddAsync(newUser);
                var result = _context.SaveChanges();
                if (!(result > 0)) return null;

                return request;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new UserDto();
            }
        }

        public static User user = new User();

        public async Task<string> Login(UserDto request)
        {
            try
            {
                //var data = await _context.Users.FirstOrDefaultAsync(user => user.RegNumber == request.RegNumber);
                var data = await _context.Users.Where(user => user.RegNumber == request.RegNumber).FirstOrDefaultAsync();
                if (data == null) return "Invalid RegNumber or Password";

                if (!VerifyPasswordHash(request.Password, data.PasswordHash, data.PasswordSalt))
                {
                    return "Invalid RegNumber or Password";
                }

                string token = CreateToken(user);

                return token;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name as string, user.RegNumber),
                new Claim(ClaimTypes.SerialNumber as string, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credential);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
