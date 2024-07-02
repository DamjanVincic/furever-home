using FureverHome.Models;
using FureverHome.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FureverHome.Services
{
    public class VolunteerService
    {
        public static User? LoggedInUser { get; private set; }
        private readonly UserService _userService;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;

        public VolunteerService(UserService userService, IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _userService = userService;
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }
        public void Add(string? firstName, string? lastName, string? username, string? password, Gender gender, string? phone,
        string? adress)
        {
            if (_accountRepository.GetAll().Any(account => account.UserName.Equals(username)))
                throw new InvalidInputException("Username already exists");
            User user = new(firstName!, lastName!, gender, phone!, adress!);
            _userRepository.Add(user);
            _accountRepository.Add(new(username!, password!, user.Id, AccountType.Volunteer, AccountStatus.Active));
        }

        internal void RejectRegistrationRequest(int id)
        {
            throw new NotImplementedException();
        }

        internal void ApproveRegistrationRequest(int id)
        {
            throw new NotImplementedException();
        }
    }
}
