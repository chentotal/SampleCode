using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Sample
{
    public static class Extension
    {
        /// <summary>
        /// 深層複製資料結構
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original"></param>
        /// <returns></returns>
        public static T Clone<T>(this T original)
        {
            if (original == null)
            {
                return default;
            }
            
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = false,
                PropertyNameCaseInsensitive = true
            };
            
            var json = JsonSerializer.Serialize(original, options);
            return JsonSerializer.Deserialize<T>(json);
        }

        /// <summary>
        /// database 取資料用, 找不到資料會印出訊息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="database"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetData<T>(this Dictionary<int, T> database, int key)
        {
            if (!database.TryGetValue(key, out var rtnValue))
            {
                Debug.WriteLine("取不到 {0} - key:{1}", typeof(T).Name, key);
            }

            return rtnValue;
        }
    }
}
