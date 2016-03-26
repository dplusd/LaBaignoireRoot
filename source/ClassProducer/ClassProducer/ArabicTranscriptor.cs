using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProducer
{
    class ArabicTranscriptor
    {

        static readonly string CHAR_MAP_FILE = "charMap.txt";
        internal static readonly Dictionary<char, string> CHAR_MAP;

        static ArabicTranscriptor()
        {
            try
            {
                CHAR_MAP = LoadCharMap();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error loading character map");
            }
        }
        static Dictionary<char, string> LoadCharMap()
        {
            Dictionary<char, string> RetVal = new Dictionary<char, string>();
            StreamReader reader = new StreamReader(CHAR_MAP_FILE);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] cols = line.Split(new char[] { '\t' });
                RetVal.Add(cols[0][0], cols[2]);
            }
            reader.Close();
            return RetVal;

        }

        public static string Transcript(string source)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in source)
            {
                if (CHAR_MAP.ContainsKey(c))
                    sb.Append(CHAR_MAP[c]);
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
