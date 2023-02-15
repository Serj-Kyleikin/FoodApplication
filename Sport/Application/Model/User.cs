

namespace Sport.Application.Model
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }

        public string Gender {get; set; }
        public DateTime BirthDate { get; set; }

        public double Weight {get; set; }

        public double Height { get; set; }

        public int Age { 
            get { 
                // DateTime nowDate = DateTime.Today;
                // int age = nowDate.Year - BirthDate.Year;
                // if(BirthDate > nowDate.AddYears(-age)) age--;

                return DateTime.Now.Year - BirthDate.Year;
            }
        }

        public User() {
            Name = "";
            Gender = "";
        }

        public User(string name, 
                    string gender, 
                    DateTime birthDate, 
                    double weight, 
                    double height
        ) 
        {
            #region Проверка условий
            if(string.IsNullOrWhiteSpace(name)) {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }

            if(gender == null) {
                throw new ArgumentNullException("Пол не может быть пустым", nameof(gender));
            }

            if(birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now) {
                throw new ArgumentException("Некорректная дата рождения", nameof(birthDate));
            }

            if(weight <= 0) {
                throw new ArgumentException("Вес не может быть пустым", nameof(weight));
            }

            if(height <= 0) {
                throw new ArgumentException("Рост не может быть пустым", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
    }
}