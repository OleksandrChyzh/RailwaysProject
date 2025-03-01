﻿using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Validation; 
using DAL.Entities;
using DAL.Interfaces;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : GenericService<User, UserModel>, IUserService
    {
        protected override IRepository<User> _repository { get; }

        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork uof, IMapper mapper)
            : base(uof, mapper)
        {
            _userRepository = uof.UserRepository;
            _repository = _userRepository;
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user is null)
            {
                throw new UserNotFoundException(email); 
            }

            return _mapper.Map<UserModel>(user);
        }
    }
}
