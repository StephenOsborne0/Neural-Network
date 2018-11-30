using System;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace NeuralNetwork
{
    public class Serialization
    {
        public static void Serialize<T>(string filePath, object obj)
            where T : class
        {
            var ext = Path.GetExtension (filePath);
            switch (ext)
            {
                case ".json":
                var js = new JsonSerializer ();

                using (var sw = new StreamWriter (filePath))
                {
                    js.Serialize (sw, obj);
                }

                break;
                default:
                var xs = new XmlSerializer (typeof (T));
                using (var sw = new StreamWriter (filePath))
                {
                    xs.Serialize (sw, obj);
                }

                return;
            }
        }

        public static T Deserialize<T>(string filePath)
            where T : class
        {
            try
            {
                var ext = Path.GetExtension (filePath);
                switch (ext)
                {
                    case ".json":
                    using (var sr = new StreamReader (filePath))
                    {
                        return JsonConvert.DeserializeObject<T> (sr.ReadToEnd ());
                    }
                    default:
                    var xs = new XmlSerializer (typeof (T));
                    using (var sr = new StreamReader (filePath))
                    {
                        return (T)xs.Deserialize (sr);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception (e.ToString ());
            }
        }
    }
}
