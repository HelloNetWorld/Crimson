using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Crimson.Services
{
    /// <summary>
    /// Сохранение и чтение объектов в/из файла JSON.
    /// </summary>
    public class SaverLoader
    {
        /// <summary>
        /// Сохранение объекта в файл JSON.
        /// </summary>
        public static void Save<T>(T obj, string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            File.WriteAllText(filePath, JsonConvert.SerializeObject(obj));
        }

        /// <summary>
        /// Чтение объекта из файла JSON.
        /// </summary>
        public static T Load<T>(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
        }
    }
}
