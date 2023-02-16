using System.Text.Json;
using System.Text.Encodings.Web;

namespace Sport.Application.Controller
{
    public abstract class ControllerBase
    {
        protected void Save<T>(string fileName, T item)
        {
            try {

                JsonSerializerOptions options = new JsonSerializerOptions {

                    // Отключение экранирования и включение форматирования.

                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                string data =  JsonSerializer.Serialize(item, typeof(T), options);

                StreamWriter file = File.CreateText(fileName);
                file.WriteLine(data);
                file.Close();

            } catch (Exception ex) {

                Console.WriteLine($"Ошибка: {ex.Message} \n\n");
                pr(ex.StackTrace);
            }
        }

        protected T Load<T>(string fileName)
        {
            try {

                if(File.Exists(fileName)) {

                    string data = File.ReadAllText(fileName);
                    return JsonSerializer.Deserialize<T>(data)!;

                } else return default(T)!;

            } catch(Exception ex) {

                Console.WriteLine($"Ошибка: {ex.Message} \n\n");
                pr(ex.StackTrace);

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