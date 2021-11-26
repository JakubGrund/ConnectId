using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectId
{
    public class File
    {
        public static string ReadAllFile(string file)
        {
            string content = "";
            //StreamReader sr = new StreamReader(soubor);
            using (StreamReader sr = new StreamReader(file))
            {
                content = sr.ReadToEnd();
            }
            //sr.Close();
            Console.WriteLine(content);
            return content;
        }
    }
}
