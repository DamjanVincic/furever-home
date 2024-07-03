using FureverHome.Models;
using FureverHome.Repositories;

namespace FureverHome.Services
{
    public class UserService
    {
        public static Account? LoggedInAccount { get; private set; }

        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;

        public UserService(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User? GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public List<User> GetPendingUsers()
        {
            var pendingAccounts = _accountRepository.GetAll().Where(acc => acc.Status == AccountStatus.Pending);
            return pendingAccounts.Select(acc => acc.User).ToList();
        }

        // user registration
        public void Add(string? firstName, string? lastName, string? username, string? password, Gender gender,
            string? phone, string? address)
        {
            if (_accountRepository.GetAll().Any(account => account.UserName.Equals(username)))
                throw new InvalidInputException("Username already exists");

            User user = new(firstName!, lastName!, gender, phone!, address!);
            var userId = _userRepository.Add(user);
            _accountRepository.Add(new Account(username!, password!, userId, AccountType.User, AccountStatus.Pending));
        }

        public void Update(int id, string? firstName, string? lastName, Gender gender, string? phone,
            string? address)
        {
            User user = _userRepository.GetById(id) ?? throw new InvalidInputException("User doesn't exist");

            user.FirstName = firstName!;
            user.LastName = lastName!;
            user.Gender = gender;
            user.Phone = phone!;
            user.Adress = address!;

            _userRepository.Update(user);
        }

        public void Delete(int id)
        {
            _ = _userRepository.GetById(id) ?? throw new InvalidOperationException("User doesn't exist");

            _userRepository.Delete(id);

            if (LoggedInAccount?.UserId == id)
                LoggedInAccount = null;
        }

        public Account Login(string username, string password)
        {
            Account account =
                _accountRepository.GetAll().FirstOrDefault(account =>
                    account.UserName.Equals(username) && account.Password.Equals(password)) ??
                throw new InvalidInputException("Invalid username or password.");

            switch (account.Status)
            {
                case AccountStatus.Pending:
                    throw new InvalidInputException("You are on the approval waiting list.");
                case AccountStatus.Blacklisted:
                    throw new InvalidOperationException("You are on the black list.");
                default:
                    LoggedInAccount = account;
                    return account;
            }
        }

        public void Logout()
        {
            if (LoggedInAccount == null)
                throw new InvalidInputException("Already logged out.");

            LoggedInAccount = null;
        }
    }
}