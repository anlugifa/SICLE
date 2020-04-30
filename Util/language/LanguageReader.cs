using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace Util.Language
{
    public class LanguageReader    
    {
        public const String COMMENT = "#";

        public async Task<Dictionary<String, String>> Read(String filePath)
        {
            var translator = new Dictionary<string, string>();

            using (StreamReader sr = new StreamReader(filePath)) 
            {
                while (sr.Peek() >= 0) 
                {
                    var line = await sr.ReadLineAsync();
                    ReadLine(translator, line);                    
                }
            }

            return translator;
        }

        private void ReadLine(Dictionary<string, string> translator, String line)
        {
            if (String.IsNullOrEmpty(line) || line.StartsWith(COMMENT) )
                return;

            var words = line.Split('=');
            if (words.Length == 2)
                translator.Add(words[0].Trim(), words[1].Trim());
        }
    }
}