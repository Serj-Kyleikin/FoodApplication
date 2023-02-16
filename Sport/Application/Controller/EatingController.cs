using Sport.Application.Model;

namespace Sport.Application.Controller
{
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "DB/Foods.json";
        private const string EATINGS_FILE_NAME = "DB/Eatings.json";
        private readonly User user;

        public List<Food> Foods { get; }

        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));

            Foods = GetAllFoods();
            Eating = GetEatings();
        }

        public void AddConsumedFood(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);

            if(product == null) {

                Foods.Add(food);
                Eating.AddEating(food, weight);
  
            } else Eating.AddEating(product, weight);

            Save();
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        private Eating GetEatings()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
        }
    }
}