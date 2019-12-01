using System.IO;

namespace DataAccess_Layer
{
    public static class DataAccess
    {
        private static string path;
        static DataAccess()
        {
            path = @"DataBase.rtf";
            if (!File.Exists(path))
                File.Create(path);
        }
        public static string Read()
        {
            string text;
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            return text;
        }
        public static void Write(string text, bool append = true)
        {
            using (StreamWriter sw = new StreamWriter(path, append))
            {
                sw.Write(text);
            }
        }
    }
}
