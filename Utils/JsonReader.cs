using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Automatización.Utils
{
    public class JsonReader
    {

        public static LoginData ReadLoginData()
        {
            string path = Path.Combine("C:\\Users\\lisse\\source\\repos\\Proyecto_Automatizaci-n\\TestData","data.json");
            string json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<LoginData>(json);
        }
    }
}
