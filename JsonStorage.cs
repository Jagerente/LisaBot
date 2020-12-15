using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace LisaBot
{
    internal class JsonStorage
    {
        private static Dictionary<string, string> _dictionary;
        private static List<string> _list;

        /// <summary>
        /// Restores object from file
        /// </summary>
        /// <param name="path">File path</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T RestoreObject<T>(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Stores object to file
        /// </summary>
        /// <param name="obj">Object to store</param>
        /// <param name="path">File path</param>
        public void StoreObject(object obj, string path)
        {
            var file = path;
            Directory.CreateDirectory(Path.GetDirectoryName(file));
            var json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(file, json);
        }

        /// <summary>
        /// Returns value from file using key
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="key">Key that keeps value</param>
        /// <returns></returns>
        public string GetValue(string path, string key)
        {
            var data = RestoreObject<dynamic>(path);
            _dictionary = data.ToObject<Dictionary<string, string>>();
            return _dictionary.ContainsKey(key) ? _dictionary[key] : "";
        }

        /// <summary>
        /// Returns value from file using it's position
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="pos">Position</param>
        /// <returns></returns>
        public string GetValue(string path, int pos)
        {
            var data = RestoreObject<dynamic>(path);
            _list = data.ToObject<List<string>>();
            return _list[pos];
        }

        /// <summary>
        /// Stores value to file using key
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void SetValue(string path, string key, string value)
        {
            var data = RestoreObject<dynamic>(path); ;
            value = data.ToObject<Dictionary<string, string>>();
            if (_dictionary.ContainsKey(key))
                _dictionary[key] = value;
            else return;
        }

        /// <summary>
        /// Returns key:value count from file
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns></returns>
        public int GetCount(string path)
        {
            var data = RestoreObject<dynamic>(path);
            _list = data.ToObject<List<string>>();
            return _list.Count;
        }
    }
}