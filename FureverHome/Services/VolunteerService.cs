using FureverHome.Models;
using FureverHome.Repositories;

namespace FureverHome.Services
{
    public class VolunteerService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;

        public VolunteerService(IAccountRepository accountRepository, IUserRepository userRepository)
        {
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

        public void RejectRegistrationRequest(int userId)
        {
            List<Account> accounts = _accountRepository.GetAll().Where(account => account.UserId == userId).ToList() ?? throw new Exception("Account does not exist");
            _accountRepository.Delete(accounts[0].Id);
            _userRepository.Delete(userId);
        }

        public void ApproveRegistrationRequest(int userId)
        {
            List<Account> accounts = _accountRepository.GetAll().Where(account => account.UserId == userId).ToList() ?? throw new Exception("Account does not exist");
            accounts[0].Status = AccountStatus.Active;
        }
    }
}
