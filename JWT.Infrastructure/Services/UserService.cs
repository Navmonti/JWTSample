using JSWSample.Domain.Auth;
using JSWSample.Domain.IServices;
using JSWSample.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSWSample.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;  
        }

        public async Task<User> Insert(User user)
        {
            try
            {
                return await _userRepository.Insert(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> Update(User user)
        {
            try
            {
                return await _userRepository.Update(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<User> Delete(User user)
        {
            try
            {
                return await _userRepository.Delete(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                return await _userRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetById(int userId)
        {
            try
            {
                return await _userRepository.GetById(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetByUsername(string username)
        {
            try
            {
                return await _userRepository.GetByUsername(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
