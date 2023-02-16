using Sport.Application.Controller;
using Sport.Application.Model;
using System.Resources;

namespace Sport.Application
{
    public class Fitness
    {
        static void Main()
        {
            // ResourceManager rm = new ResourceManager("Messages", typeof(Fitness).Assembly);
            // Console.WriteLine(rm.GetString("Hello"));

            Console.WriteLine("Введите имя пользователя:");
            var name = Console.ReadLine()!;

            var userController = new UserController(name);

            if(userController.IsNewUser) {

                Console.WriteLine("Введите пол:");
                var gender = Console.ReadLine()!;
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                userController.SetNewUserData(name, gender, birthDate, weight, height);
            }

            Console.WriteLine("Главное меню");
            Console.WriteLine("____________");
            Console.WriteLine("Е - Ввести приём пищи");

            var key = Console.ReadKey();
            
            if(key.Key == ConsoleKey.E) {

                var foods = EnterEating();
 
                var eatingController = new EatingController(userController.CurrentUser);
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods) {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }
        }

        private static double ParseDouble(string name)
        {
            while(true) {

                Console.WriteLine($"Введите {name}:");

                if(double.TryParse(Console.ReadLine(), out double value)) return value;
                else Console.WriteLine($"Неверный формат поля: {name}!");
            }
        }

        private static DateTime ParseDateTime()
        {
            while(true) {

                Console.WriteLine("Введите дату рождения (dd.MM.yyyy):");

                if(DateTime.TryParse(Console.ReadLine(), out DateTime birthDate)) return birthDate;
                else Console.WriteLine("Неверный формат даты!");
            }
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Ввести имя продукта:");
            var food = Console.ReadLine()!
            ;

            var weight = ParseDouble("вес порции");
            var calories = ParseDouble("калорийность");
            var prot = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");

            var product = new Food(food, calories, prot, fats, carbs);

            return (Food: product, Weight: weight);
        }
    }
}
