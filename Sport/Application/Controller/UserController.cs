using Sport.Application.Model;

namespace Sport.Application.Controller
{
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "DB/Users.json";

        public List<User> Users { get; }

        public User CurrentUser { get; set; } = default!;

        public bool IsNewUser { get; } = false;

        public UserController(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName)) {
                throw new ArgumentNullException("имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsersData() ?? new List<User>();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName)!;

            if(CurrentUser == null) {
                IsNewUser = true;
            }
        }

        private List<User> GetUsersData()
        {
            return Load<List<User>>(USERS_FILE_NAME);
        }

        public void SetNewUserData(string userName, string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser = new User();

            CurrentUser.Name = userName;
            CurrentUser.Gender = genderName;
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

            Users.Add(CurrentUser);
            Save(USERS_FILE_NAME, Users);
        }
    }
}