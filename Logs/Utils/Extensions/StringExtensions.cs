using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Sicle.Logs.Extensions
{
    /// <summary>
    /// Métodos de extensão para tipo String
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Remove um determinado valor do final de uma string
        /// </summary>
        /// <param name="s">String a ser alterada</param>
        /// <param name="value">Valor a ser removido</param>
        /// <returns>String com o valor removido do final</returns>
        public static string TrimEnd(this string s, string value)
        {
            if (s.IsNullOrWhiteSpace() || !s.EndsWith(value))
            {
                return s;
            }
            else
            {
                return s.Remove(s.LastIndexOf(value, StringComparison.Ordinal));
            }
        }

        /// <summary>
        /// Remove um determinado valor do final de uma string, ignorando case
        /// </summary>
        /// <param name="s">String a ser alterada</param>
        /// <param name="value">Valor a ser removido</param>
        /// <returns>String com o valor removido do final</returns>
        public static string TrimEndIgnoreCase(this string s, string value)
        {
            if (s.IsNullOrWhiteSpace() || !s.EndsWith(value, StringComparison.OrdinalIgnoreCase))
            {
                return s;
            }
            else
            {
                return s.Remove(s.LastIndexOf(value, StringComparison.OrdinalIgnoreCase));
            }
        }

        /// <summary>
        /// Busca a última posição de uma determinada string dentro de outra, desconsiderando a cultura (InvariantCulture)
        /// </summary>
        /// <param name="s">String cujo conteúdo será analisado</param>
        /// <param name="value">String cujo valor será buscado</param>
        /// <returns>Inteiro indicando o índice da última posição onde o valor foi encontrado</returns>
        public static int LastIndexOfInvariant(this string s, string value)
        {
            return s.LastIndexOf(value, StringComparison.Ordinal);
        }

        /// <summary>
        /// Converte uma string para Lower Case, desconsiderando a cultura (InvariantCulture)
        /// </summary>
        /// <param name="s">String a ser convertida</param>
        /// <returns>String convertida para Lower Case</returns>
        public static string ToLowerInvariant(this string s)
        {
            return s.ToLower(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Remove caracteres excedentes do final de uma string, baseado no tamanho máximo especificado
        /// </summary>
        /// <param name="s">String a ser truncada</param>
        /// <param name="maxLength">Máximo de caracteres permitidos</param>
        /// <returns>String truncada, caso seu tamanho exceda a quantidade máxima de caracteres permitidos</returns>
        public static string Truncate(this string s, int maxLength)
        {
            if (string.IsNullOrEmpty(s)) return null;

            if (s.Length > maxLength)
                return s.Substring(0, maxLength);
            else
                return s;
        }

        /// <summary>
        /// Trata cenários de objeto nulo na conversão para string
        /// </summary>
        /// <param name="o">Objeto a ser convertido</param>
        /// <returns>String vazia, caso o objeto esteja nulo. Objeto convertido em string, caso contrário.</returns>
        public static string ToStringOrEmpty(this object o)
        {
            return (o == null ? string.Empty : o.ToString());
        }

        /// <summary>
        /// Trata cenários de objeto nulo na conversão para string
        /// </summary>
        /// <param name="o">Objeto a ser convertido</param>
        /// <param name="valueIfNull">Valor a ser utilizado caso o objeto seja nulo</param>
        /// <returns>Valor informado, caso o objeto esteja nulo. Objeto convertido em string, caso contrário.</returns>
        public static string ToStringOrValue(this object o, string valueIfNull)
        {
            return (o == null ? valueIfNull : o.ToString());
        }

        /// <summary>
        /// Utiliza um determinado valor definido, caso a string seja nula ou vazia
        /// </summary>
        /// <param name="o">String a ser verificada</param>
        /// <param name="valueIfNullOrWhiteSpace">Valor a ser utilizado caso a string seja nula ou vazia</param>
        /// <returns>Valor da própria string, caso esta não seja nula ou vazia. Valor informado, caso contrário</returns>
        public static string ToValueIfNullOrEmpty(this string o, string valueIfNullOrEmpty)
        {
            return (o.IsNullOrEmpty() ? valueIfNullOrEmpty : o);
        }

        /// <summary>
        /// Utiliza um determinado valor definido, caso a string seja nula ou tenha apenas espaços em branco
        /// </summary>
        /// <param name="o">String a ser verificada</param>
        /// <param name="valueIfNullOrWhiteSpace">Valor a ser utilizado caso a string seja nula ou tenha apenas espaços em branco</param>
        /// <returns>Valor da própria string, caso esta não seja nula ou tenha apenas espaços em branco. Valor informado, caso contrário</returns>
        public static string ToValueIfNullOrWhiteSpace(this string o, string valueIfNullOrWhiteSpace)
        {
            return (o.IsNullOrWhiteSpace() ? valueIfNullOrWhiteSpace : o);
        }

        /// <summary>
        /// Verifica se a string é nula ou vazia
        /// </summary>
        /// <param name="s">String a ser verificada</param>
        /// <returns>True se string é nula ou vazia, False caso contrário</returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// Verifica se a string é nula ou possui apenas espaços em branco
        /// </summary>
        /// <param name="s">String a ser verificada</param>
        /// <returns>True se string é nula ou possui apenas espaços em branco, False caso contrário</returns>
        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// Compara duas strings ignorando case
        /// </summary>
        /// <param name="s1">String a ser comparada</param>
        /// <param name="s2">String a ser comparada</param>
        /// <returns>True se strings são iguais, False caso contrário</returns>
        public static bool EqualsIgnoreCase(this string s1, string s2)
        {
            return string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Compara duas strings ignorando case e espaços em branco
        /// </summary>
        /// <param name="s1">String a ser comparada</param>
        /// <param name="s2">String a ser comparada</param>
        /// <returns>True se strings são iguais, False caso contrário. Cenários nulos não são considerados match.</returns>
        public static bool EqualsTrimIgnoreCase(this string s1, string s2)
        {
            return EqualsIgnoreCase(s1.SafeTrim(), s2.SafeTrim());
        }

        /// <summary>
        /// Compara duas strings, considerando iguais se ambas são nulas, vazias ou possuem apenas espaços em branco
        /// </summary>
        /// <param name="s1">String a ser comparada</param>
        /// <param name="s2">String a ser comparada</param>
        /// <returns>True se ambas as strings são nulas, vazias ou possuem apenas espaços em branco, False caso contrário</returns>
        public static bool EqualsNullWhiteSpace(this string s1, string s2)
        {
            return s1.IsNullOrWhiteSpace() && s2.IsNullOrWhiteSpace();
        }

        /// <summary>
        /// Verifica se uma string está contida em outra, ignorando case
        /// </summary>
        /// <param name="s1">String a ser comparada</param>
        /// <param name="s2">String a ser comparada</param>
        /// <returns>True s2 está contida em s1, False caso contrário. Cenários nulos não são considerados match.</returns>
        public static bool ContainsIgnoreCase(this string s1, string s2)
        {
            if (s1 == null || s2 == null) return false;
            return s1.IndexOf(s2, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Verifica se uma string está contida em outra, ignorando case e espaços em branco
        /// </summary>
        /// <param name="s1">String a ser comparada</param>
        /// <param name="s2">String a ser comparada</param>
        /// <returns>True s2 está contida em s1, False caso contrário</returns>
        public static bool ContainsTrimIgnoreCase(this string s1, string s2)
        {
            return ContainsIgnoreCase(s1.SafeTrim(), s2.SafeTrim());
        }

        /// <summary>
        /// Remove espaços em branco de maneira segura, tratando situações em que a string é nula
        /// </summary>
        /// <param name="s1">String cujos espaços em branco serão removidos</param>
        /// <returns>String espaços em branco</returns>
        public static string SafeTrim(this string s1)
        {
            return string.IsNullOrEmpty(s1) ? s1 : s1.Trim();
        }

        /// <summary>
        /// Remove qualquer caracter "/" no início de uma string
        /// </summary>
        /// <param name="s1">String cujos caracteres "/" serão removidos do início</param>
        /// <returns>String sem os caracteres "/" no início</returns>
        public static string TrimLeadingSlashes(this string s1)
        {
            return string.IsNullOrEmpty(s1) ? s1 : s1.TrimStart('/');
        }

        /// <summary>
        /// Remove qualquer caracter "/" no final de uma string
        /// </summary>
        /// <param name="s1">String cujoos caracteres "/" serão removidos do final</param>
        /// <returns>String sem os caracteres "/" no final</returns>
        public static string TrimTrailingSlashes(this string s1)
        {
            return string.IsNullOrEmpty(s1) ? s1 : s1.TrimEnd('/');
        }

        /// <summary>
        /// Remove qualquer caracter "/" no início e no fim de uma string
        /// </summary>
        /// <param name="s1">String cujos caracteres "/" serão removidos do início e do fim</param>
        /// <returns>String sem os caracteres "/" no início e no fim</returns>
        public static string TrimSlashes(this string s1)
        {
            return string.IsNullOrEmpty(s1) ? s1 : s1.Trim('/');
        }

        /// <summary>
        /// Remove acentuação de uma determinada string
        /// </summary>
        /// <param name="text">String cuja acentuação deve ser removida</param>
        /// <returns>String sem acentuação</returns>
        /// <remarks>
        /// Fonte: http://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net
        /// </remarks>
        public static string RemoveAccents(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Realiza append de um determinado formato, e pula linha
        /// </summary>
        /// <param name="sb">Instância de StringBuilder</param>
        /// <param name="format">Formato a ser aplicado</param>
        /// <param name="value">Valor a ser formatado</param>
        public static void AppendFormatLine(this StringBuilder sb, string format, object value)
        {
            if (sb != null)
            {
                sb.AppendFormat(format, value);
                sb.AppendLine();
            }
        }

        /// <summary>
        /// Indica se uma determinada string representa uma URL absoluta
        /// </summary>
        /// <param name="value">String a ser verificada</param>
        /// <returns>A string representa uma URL absoluta (true) ou não (false)</returns>
        public static bool IsAbsoluteUrl(this string value)
        {
            Uri uri;
            return Uri.TryCreate(value, UriKind.Absolute, out uri);
        }
    }
}