using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLL.Constraints
{
    public static class JsonConverter
    {
        public static async Task ObjectConvert(object o)
        {
            string filePath = "D:\\Constraint.json";
            string json = JsonSerializer.Serialize(o);
            await File.WriteAllTextAsync(filePath, json);
        }

        public static async Task<T> ReadConstraint<T>(string filePath)
        {
            FileStream fileStream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<T>(fileStream);
        }
    }
}
