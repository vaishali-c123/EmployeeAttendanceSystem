using EmployeeAttendanceSystem.Data;
using EmployeeAttendanceSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeAttendanceSystem.Services.AccountServices
{
	
	public class AccountService : IAccountService
	{
		private readonly EmployeeAttendanceSystemContext _context;
		private readonly IConfiguration _configuration;

		public AccountService(EmployeeAttendanceSystemContext context, IConfiguration configuration)
		{
			this._context = context;
			this._configuration = configuration;
		}
		private void VerifyPasswordHash(string password, out string passwordHash)
		{
			using (var hmac = new System.Security.Cryptography.HMACSHA512())
			{

				hmac.Key = System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Encryption:SHAKEY").Value);
				passwordHash = BitConverter.ToString(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
			}
		}
		private string GenerateToken(Employee employee)
		{
			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.NameIdentifier, employee.EmployeeId),
				new Claim(ClaimTypes.Name, employee.EmployeeName),

			};
            var temp=_configuration.GetSection("Encryption:SHAKEY").Value;
			var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Encryption:SHAKEY").Value));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var tokenDescriptor = new SecurityTokenDescriptor()
			{
				Subject = new ClaimsIdentity(claims),
				Expires = System.DateTime.Now.AddDays(1),
				SigningCredentials = creds

			};
			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
		private string GenerateToken(Admin admin)
		{
			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.NameIdentifier, admin.AdminId),
				new Claim(ClaimTypes.Name, admin.AdminUsername),

			};
			var temp = _configuration.GetSection("Encryption:SHAKEY").Value;
			var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Encryption:SHAKEY").Value));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var tokenDescriptor = new SecurityTokenDescriptor()
			{
				Subject = new ClaimsIdentity(claims),
				Expires = System.DateTime.Now.AddDays(1),
				SigningCredentials = creds

			};
			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

		public async Task<LoginResponse> Login(Loginrequest user)
		{
			if (user.EmployeeType.ToLower() == "Employee".ToLower())
			{
				var userInDB = await _context.Employees.SingleOrDefaultAsync(u => u.EmployeeUsername.Equals(user.Username));
				if (userInDB is null)
				{
					return new LoginResponse() { Token = null, responseMsg = "authentication failed" };


				}
				this.VerifyPasswordHash(user.Password, out string pass);
				if (userInDB.EmployeePassword.Equals(pass))
				{
					return new LoginResponse { Token = this.GenerateToken(userInDB), responseMsg = "employee" };
				}
				else
				{
					return new LoginResponse() { Token = null, responseMsg = "authentication failed" };

				}
			}
			else
			{

				var userInDB = await _context.Admins.SingleOrDefaultAsync(u => u.AdminUsername.Equals(user.Username));
				if (userInDB is null)
				{
					return new LoginResponse() { Token = null, responseMsg = "authentication failed" };

				}
				
				this.VerifyPasswordHash(user.Password, out string pass);
				if (userInDB.AdminPassword.Equals(pass))
				{
					return new LoginResponse { Token = this.GenerateToken(userInDB), responseMsg = "admin" };
				}
				else
				{
					return new LoginResponse() { Token = null, responseMsg = "authentication failed" };

				}


			}
		}
	}
}

