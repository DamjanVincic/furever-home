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
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;

        public VolunteerService(IAccountRepository accountRepository, IUserRepository userRepository)
        {
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

        public void RejectRegistrationRequest(int userId)
        {
            List<Account> accounts = (List<Account>)_accountRepository.GetAll().Where(account => account.UserId == userId).ToList() ?? throw new Exception("Account does not exist");
            _accountRepository.Delete(accounts[0].Id);
            _userRepository.Delete(userId);
        }

        public void ApproveRegistrationRequest(int userId)
        {
            List<Account> accounts = (List<Account>)_accountRepository.GetAll().Where(account => account.UserId == userId).ToList() ?? throw new Exception("Account does not exist");
            accounts[0].Status = AccountStatus.Active;
        }
    }
}
