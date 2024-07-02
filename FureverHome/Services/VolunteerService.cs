using FureverHome.Models;
using FureverHome.Repositories;

namespace FureverHome.Services
{
    public class VolunteerService
    {
        private readonly UserService _userService;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;

        public VolunteerService(UserService userService, IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _userService = userService;
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        public void Add(string? firstName, string? lastName, string? username, string? password, Gender gender, string? phone, string? address)
        {
            if (_accountRepository.GetAll().Any(account => account.UserName.Equals(username)))
                throw new InvalidInputException("Username already exists");

            User user = new(firstName!, lastName!, gender, phone!, address!);
            int userId = _userRepository.Add(user);
            _accountRepository.Add(new Account(username!, password!, userId, AccountType.Volunteer, AccountStatus.Active));
        }

    }
}
