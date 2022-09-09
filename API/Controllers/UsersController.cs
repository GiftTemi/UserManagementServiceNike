using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Common;
using Domain.DTOs.User;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;


        public UsersController(AppDbContext context, IMapper mapper, ILogger<UsersController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public object createUser { get; private set; }

        // GET: api/Users
        [HttpGet("getallusers")]
        public async Task<Responses> GetUsers()
        {
            try
            {
                _logger.LogInformation("Getting All users...");
                var findUsers = await _context.Users.ToListAsync();
                if (findUsers == null)
                {
                    return Responses.Failure("Users Not Found");
                }
                return Responses.Success("Suceeded, findUsers");

            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }
        // GET: api/Users/5
        [HttpGet("getuserbyid/{id}")]
        public async Task<Responses> GetUser(int id)
        {
            try
            {
                var findUser = await _context.Users.Where(q => q.Id == id).FirstOrDefaultAsync();
                if (findUser == null)
                    return Responses.Failure($"User with Id {id} not found");
                else
                    return Responses.Success("suceeded", findUser);
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }

        }
        [HttpPost("createuser")]
        public async Task<Responses> CreateUser(CreateUserDTO createuser)
        {
            try
            {
                //same as 2 lines below
                //var user = new User
                //{
                //    FirstName = createuser.FirstName,
                //    LastName = createuser.LastName,
                //    EmailAddress = createuser.EmailAddress,
                //    DOB = createuser.DOB,
                //};
                var mappedUser = _mapper.Map<User>(createUser);
                _context.Users.Add(mappedUser);
                await _context.SaveChangesAsync();

                return Responses.Success("User Created Successfully");
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("deleteuser{id}")]
        public async Task<Responses> DeleteUser(int id, User user)
        {
            try
            {
                var findUser = _context.Users.Where(p => p.Id == id).FirstOrDefault();
                if (findUser == null)
                {
                    return Responses.Failure("User not found");
                }
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return Responses.Success("User deleted Successfully");
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }

        private async Task<Responses> UpdateUser(int id, User user)
        {
            try
            {
                var findUser = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
                if (findUser == null)
                    return Responses.Failure("User Not Found");
                else
                {
                    findUser.DOB = user.DOB;
                    findUser.Status = user.Status;
                    findUser.DateModified = user.DateModified;
                    findUser.FirstName = user.FirstName;
                    findUser.LastName = user.LastName;

                    _context.Update(findUser);
                    await _context.SaveChangesAsync();
                    return Responses.Success("User updated successfully", findUser);
                }

            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }
    }
}