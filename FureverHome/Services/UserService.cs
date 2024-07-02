using FureverHome.Models;
using FureverHome.Repositories;

namespace FureverHome.Services
{
    public class UserService
    {
        public static User? LoggedInUser { get; private set; }
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

        public void Add(string? firstName, string? lastName, string? username, string? password, Gender gender, string? phone,
            string? adress)
        {
            if (_accountRepository.GetAll().Any(account => account.UserName.Equals(username)))
                throw new InvalidInputException("Username already exists");

            Account account = new(username!, password!, AccountType.User);
            int accountId = _accountRepository.Add(account);
            account.Id = accountId;
            _userRepository.Add(new User(firstName!, lastName!, gender, phone!, adress!, account));
        }

        public void Update(int id, string? firstName, string? lastName, string? username, string? password, Gender gender, string? phone,
            string? adress, AccountType accountType)
        {
            User user = _userRepository.GetById(id) ?? throw new InvalidInputException("User doesn't exist");

            user.FirstName = firstName!;
            user.LastName = lastName!;
            user.Account.Password = password!;
            user.Account.UserName = username!;
            user.Account.Type = accountType;
            user.Gender = gender;
            user.Phone = phone!;
            user.Adress = adress!;

            _userRepository.Update(user);

            if (LoggedInUser?.Id == id)
                LoggedInUser = user;
        }

        public void Delete(int id)
        {
            _ = _userRepository.GetById(id) ?? throw new InvalidOperationException("User doesn't exist");

            _userRepository.Delete(id);

            if (LoggedInUser?.Id == id)
                LoggedInUser = null;
        }

        public User? Login(string username, string password)
        {
            User? user = _userRepository.GetAll()
                .FirstOrDefault(user => user.Account.UserName.Equals(username) && user.Account.Password.Equals(password));
            if (user!.Account.Status.Equals(AccountStatus.Pending))
            {
                throw new InvalidOperationException("You are on the approval waiting list.");
            }
            LoggedInUser = user;
            return user;
        }

        public void Logout()
        {
            if (LoggedInUser == null)
                throw new InvalidInputException("Already logged out.");

            LoggedInUser = null;
        }

    }
}
