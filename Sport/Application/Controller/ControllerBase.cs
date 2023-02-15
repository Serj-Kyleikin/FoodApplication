using System.Text.Json;
using System.Text.Encodings.Web;

namespace Sport.Application.Controller
{
    public abstract class ControllerBase
    {
        protected void Save(string fileName, object item)
        {
            try {

                JsonSerializerOptions options = new JsonSerializerOptions {

                    // Отключаем экранирование и одновременно включаем форматирование.

                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                string data =  JsonSerializer.Serialize(item, typeof(object), options);

                StreamWriter file = File.CreateText(fileName);
                file.WriteLine(data);
                file.Close();

            } catch (Exception ex) {

                Console.WriteLine($"Ошибка: {ex.Message} \n\n");
                Console.WriteLine(ex.StackTrace);
                Environment.Exit(500);
            }
        }

        protected T Load<T>(string fileName)
        {
            try {

                if(File.Exists(fileName)) {

                    string data = File.ReadAllText(fileName);
                    return JsonSerializer.Deserialize<T>(data);

                } else return default(T)!;

            } catch(Exception ex) {

                Console.WriteLine($"Ошибка: {ex.Message} \n\n");
                Console.WriteLine(ex.StackTrace);
                Environment.Exit(500);

                return default(T)!;
            }
        }

        protected void pr<T>(T item)
        {
            Console.Write(item);
            Environment.Exit(500);
        }
    }
}