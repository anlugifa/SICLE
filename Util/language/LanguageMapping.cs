using System;
using System.Collections.Generic;
using System.Globalization;

namespace Util.Language
{
    public class LanguageMapping
    {        
        private Dictionary<CultureInfo, LanguageConverter> MapTranslator { get; set; }

        public LanguageMapping()
        {
            MapTranslator = new Dictionary<CultureInfo, LanguageConverter>();
        }

        public bool HasCulture(CultureInfo culture)
        {
            return MapTranslator.ContainsKey(culture);
        }

        public async void Add(CultureInfo culture, String filePath)
        {
            var converter = new LanguageConverter(culture, filePath);
            MapTranslator.Add(culture, converter);

            await converter.Init();
        }

        public LanguageConverter GetConverter(CultureInfo culture)
        {
            return MapTranslator[culture];
        }

        public String Translate(CultureInfo culture, String key)
        {
            return GetConverter(culture).Translator[key];
        }


    }
}