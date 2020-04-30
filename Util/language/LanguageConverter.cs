using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace Util.Language
{
    public class LanguageConverter
    {
        private CultureInfo Culture { get; }
        private String FilePath { get; }

        public Dictionary<String, String> Translator { get; set;}

        public LanguageConverter(CultureInfo culture, String filePath)
        {
            this.Culture = culture;
            this.FilePath = filePath;

            Translator = new Dictionary<String, String>();
        }

        public async Task<Dictionary<String, String>> Init()
        {        
            Translator.Clear();            

            Translator = await new LanguageReader().Read(FilePath);

            return Translator;            
        }

        public string Translate(string key)
        {
            return Translator[key];
        }       
    }
}