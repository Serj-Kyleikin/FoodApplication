

namespace Sport.Application.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; set; }
        public double Proteins { get; }
        public double Fats { get; }
        public double Carbohydrates { get; }
        public double Calories { get; }

        #region Аксессоры
        private double CaloriesOneGramm {
            get {
                return Calories / 100.0;
            }
        }
        private double ProteinsOneGramm {
            get {
                return Proteins / 100.0;
            }
        }
        private double FatsOneGramm {
            get {
                return Fats / 100.0;
            }
        }
        private double CarbohydratesOneGramm {
            get {
                return Fats / 100.0;
            }
        }
        #endregion

        public Food() : this("", 0, 0, 0, 0) { }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }
    }
}