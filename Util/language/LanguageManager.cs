using System;
using System.Globalization;

namespace Util.Language
{
    public class LanguageManager
    {
        private static LanguageManager _instance = null;

        private LanguageMapping _mapping { get; set; }
        private CultureInfo _currentCulture { get; set; }

        private LanguageManager()
        {
            _currentCulture = CultureInfo.GetCultureInfo("pt-BR");
            _mapping = new LanguageMapping();
        }       

        public static LanguageManager Instance()
        {
            if (_instance == null)
                _instance = new LanguageManager();

            return _instance;
        }

        public void AddLanguage(CultureInfo culture, String resourceFilePath)
        {
            _mapping.Add(culture, resourceFilePath);
        }

        public void SetCulture(CultureInfo culture)
        {
            if (_mapping.HasCulture(culture))
                _currentCulture = culture;
            else
                throw new Exception("CultureInfo not supported: " + culture.DisplayName);
        }

        public LanguageConverter GetCurrentConverter()
        {
            return _mapping.GetConverter(_currentCulture);
        }

        public String Translate(String key)
        {           
            return GetCurrentConverter().Translate(key);
        }

        public String Format(string key, params Object[] values)
        {
            var value = Translate(key);
            return String.Format(value, values);
        }
    }
}