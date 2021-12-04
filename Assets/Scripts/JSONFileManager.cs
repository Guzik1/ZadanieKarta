using System;
using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    public class JSONFileManager
    {
        string path;

        public JSONFileManager(string path)
        {
            this.path = path;
        }

        public void SaveToFile(object objToSave)
        {
            Debug.Log($"Save to file, path: { path }");

            string data = JsonUtility.ToJson(objToSave);

            try
            {
                string dictionaryPath = Path.GetDirectoryName(path);

                if (!Directory.Exists(dictionaryPath))
                    Directory.CreateDirectory(dictionaryPath);

                var file = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(file);

                sw.Write(data);

                sw.Close();
                file.Close();
            }
            catch (Exception e)
            {
                Debug.LogError("Exception in save object to file: " + e.Message);
            }
        }

        public T LoadFromFile<T>()
        {
            if (!File.Exists(path))
                return default(T);

            string data = "";
            try
            {
                StreamReader sr = new StreamReader(path);

                data = sr.ReadToEnd();

                sr.Close();
            }
            catch (Exception e)
            {
                Debug.LogError("Exception on load object from file: " + e.Message);
            }

            if (data != "")
            {
                try
                {
                    return JsonUtility.FromJson<T>(data);
                }
                catch (Exception e)
                {
                    Debug.LogWarning(e.Message);
                }
            }
            
            return default(T);
        }
    }
}
