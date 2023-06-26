using System;
using System.IO;
using UnityEngine;
namespace Scenes.Scripts
{
    public class JsonToFileStorageService : IStorageService
    {
        public void Save(string key, object data, Action<bool> callback = null)
        {
            var path = BuildPath(key);
            var json = JsonUtility.ToJson(data);
            using (var fileStream = new StreamWriter(path))
            {
                fileStream.Write(json);
            }
            
            callback?.Invoke(true);
        }

        public void Load<T>(string key, Action<T> callback)
        {
            var path = BuildPath(key);
            using (var fileReading = new StreamReader(path))
            {
                var json = fileReading.ReadToEnd();
                var data = JsonUtility.FromJson<T>(json);
                
                callback.Invoke(data);
            }
            
        }

        private string BuildPath(string key)
        {
            return Path.Combine(Application.persistentDataPath, key);
        }
        
    }
}