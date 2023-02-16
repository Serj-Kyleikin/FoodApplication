

namespace Sport.Application.Model
{
    [Serializable]
    public class Eating
    {
        public DateTime Moment { get; }
        public Dictionary<string, double> Foods { get; set; } = default!;
        public User User { get; } = default!;

        public Eating() { }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<string, double>();
        }

        public void AddEating(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f == food.Name);

            if(product == null) Foods.Add(food.Name, weight);
            else Foods[food.Name] += weight;
        }
    }
}