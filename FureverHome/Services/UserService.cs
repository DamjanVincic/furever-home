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
        // user registration
        public void Add(string? firstName, string? lastName, string? username, string? password, Gender gender, string? phone,
        string? adress)
        {
            if (_accountRepository.GetAll().Any(account => account.UserName.Equals(username)))
                throw new InvalidInputException("Username already exists");
            User user = new(firstName!, lastName!, gender, phone!, adress!);
            _userRepository.Add(user);
            _accountRepository.Add(new(username!, password!, user.Id, AccountType.User, AccountStatus.Pending));
        }

        public void Update(int id, string? firstName, string? lastName, Gender gender, string? phone,
            string? adress)
        {
            User user = _userRepository.GetById(id) ?? throw new InvalidInputException("User doesn't exist");

            user.FirstName = firstName!;
            user.LastName = lastName!;
            user.Gender = gender;
            user.Phone = phone!;
            user.Adress = adress!;

            _userRepository.Update(user);
        }

        public void Delete(int id)
        {
            _ = _userRepository.GetById(id) ?? throw new InvalidOperationException("User doesn't exist");

            _userRepository.Delete(id);

            if (LoggedInAccount?.Id == id)
                LoggedInAccount = null;
        }

        public Account? Login(string username, string password)
        {
            Account? account = _accountRepository.GetAll().FirstOrDefault(account => account.UserName.Equals(username) && account.Password.Equals(password)) ?? throw new InvalidInputException("Invalid input");
            if (account!.Status.Equals(AccountStatus.Pending))
            {
                throw new InvalidOperationException("You are on the approval waiting list.");
            }
            LoggedInAccount = account;
            return account;
        }

        public void Logout()
        {
            if (LoggedInAccount == null)
                throw new InvalidInputException("Already logged out.");

            LoggedInAccount = null;
        }

    }
}
