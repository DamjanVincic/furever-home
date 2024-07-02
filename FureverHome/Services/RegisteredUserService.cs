using FureverHome.Models;
using FureverHome.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Services
{
    public class RegisteredUserService
    {
        public static User? LoggedInUser { get; private set; }
        private readonly UserService _userService;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;

        public RegisteredUserService(UserService userService, IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _userService = userService;
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

    }
}
