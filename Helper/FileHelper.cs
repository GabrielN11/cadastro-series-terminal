using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DIO.Series
{
    public class FileHelper
    {
        static string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Data", "file.json");
        public FileHelper()
        {
            try
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Data"));
            }
            catch
            {

            }
        }

        public List<Serie> getAll()
        {
            try
            {
                var json = File.ReadAllLines(path);
                var obj = JsonConvert.DeserializeObject<List<Serie>>(json[0]);
                return obj;
            }
            catch
            {
                return new List<Serie>();
            }
        }

        public void insertData(List<Serie> serie)
        {
            using (var stream = File.CreateText(path))
            {
                var json = JsonConvert.SerializeObject(serie);
                stream.WriteLine(json);
            }
        }

    }
}
