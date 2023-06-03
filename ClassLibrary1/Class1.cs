using System.Text.Json;

namespace ClassLibrary1
    {
        internal class JsonSerializerService
        {
            public T? Deserialize<T>(Func<Stream> streamFunc)
                where T : class
            {
                using var stream = streamFunc();
                using StreamReader reader = new(stream);
                string json = reader.ReadToEnd();

                try
                {
                    return JsonSerializer.Deserialize<T>(json);
                }
                catch (Exception ex)
                {

                }


                return null;
            }

            public void Serialize<T>(T data, Func<Stream> writeStream)
                where T : class
            {
                string json = JsonSerializer.Serialize(data);
                using var stream = writeStream();
                using StreamWriter writer = new(stream);
                writer.Write(json);
            }
        }
    }

