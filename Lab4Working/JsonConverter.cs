using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Windows.Forms.Design.AxImporter;

namespace Lab4Working
{
    internal class JsonConverter
    {
        private JsonConverter() { }

        public static List<Laptop> DeserialiseFromJson(String path)
        {
            using (FileStream fstream = new FileStream(path, FileMode.Open))
            {

                return JsonSerializer.Deserialize<List<Laptop>>(fstream);
            }
        }

        public static void SerializeToJson(String path, List<Laptop> laptops)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            using (FileStream fstream = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.Serialize(fstream, laptops, options);
            }
        }
    }
}
