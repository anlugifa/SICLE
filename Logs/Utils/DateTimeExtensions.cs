using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.Framework.Utils.Extensions
{
    /// <summary>
    /// Métodos de extensão para tipos DateTime? (nulável) e DateTime (não nulável)
    /// </summary>
    public static class DateTimeExtensionssss
    {
        #region Non-Nullable

        /// <summary>
        /// Retorna uma string formatada em PT-BR
        /// </summary>
        /// <param name="date"></param>
        /// <returns>String contendo a data/hora formatada em PT-BR</returns>
        public static string ToStringPtBr(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Normaliza o horário da data para o início do dia (00:00:00)
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Data com o horário normalizado para o início do dia (00:00:00)</returns>
        public static DateTime ToBeginDayTime(this DateTime date)
        {
            // Normaliza data para horário de início do dia (00:00:00)
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }

        /// <summary>
        /// Normaliza o horário da data para o final do dia (23:59:59)
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Data com o horário normalizado para o fim do dia (23:59:59)</returns>
        public static DateTime ToEndDayTime(this DateTime date)
        {
            // Normaliza data para horário de fim do dia (23:59:59)
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }

        /// <summary>
        /// Seta o horário da data para um valor específico
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hour">Hora a ser setada</param>
        /// <param name="minute">Minuto a ser setado</param>
        /// <param name="second">Segundo a ser setado</param>
        /// <returns>Data com o horário especificado</returns>
        public static DateTime ToSpecificTime(this DateTime date, int hour, int minute, int second)
        {
            // Seta um horário específico na data
            return new DateTime(date.Year, date.Month, date.Day, hour, minute, second);
        }

        /// <summary>
        /// Garante que a instância de data seja compatível com o tipo DATETIME do Sql Server. Este tipo
        /// aceita apenas datas superiores à 1/1/1753.
        /// </summary>
        /// <param name="date">Instância da data a ser verificada</param>
        /// <returns>1/1/1753, caso a data da instância seja inferior à este valor, ou a própria data da instância, caso contrário</returns>
        public static DateTime ToSqlServerCompatible(this DateTime date)
        {
            var minSqlServerDate = date.GetSqlServerMinDate();
            return (date < minSqlServerDate ? minSqlServerDate : date);
        }

        /// <summary>
        /// Retorna a data mínima compatível com campos do tipo DATETIME no Sql Server
        /// </summary>
        /// <param name="date">Instância não é utilizada</param>
        /// <returns>Data mínima: 1/1/1753</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA1801:ReviewUnusedParameters",
            MessageId = "date",
            Justification = "Não usamos a instância recebida, pois o método devolve uma data estática. Foi usado desta maneira apenas para ser possível usar a extensão em tipos DateTime.")]
        public static DateTime GetSqlServerMinDate(this DateTime date)
        {
            return new DateTime(1753, 1, 1, 0, 0, 0);
        }

        /// <summary>
        /// Retorna a diferença em minutos entre duas datas, apenas se a data da instância for maior que
        /// a data do parâmetro. Caso contrário, a diferença retornada é zero
        /// </summary>
        /// <param name="date"></param>
        /// <param name="lowerDate">Data menor do que a data da instância</param>
        /// <returns>Se a data da instância é maior que a data do parâmetro, retorna a diferença de minutos. Senão, retorna 0</returns>
        public static double TotalMinutesIfGreaterThan(this DateTime date, DateTime lowerDate)
        {
            if (date >= lowerDate)
                return date.Subtract(lowerDate).TotalMinutes;
            else
                return 0;
        }

        /// <summary>
        /// Compara duas instâncias de data, ignorando a porção de horário
        /// </summary>
        /// <param name="date1">Data a ser comparada</param>
        /// <param name="date2">Data a ser comparada</param>
        /// <returns>As datas (sem horário) são iguais (true) ou não (false)</returns>
        public static bool EqualsIgnoreTime(this DateTime date1, DateTime date2)
        {
            return date1.Date == date2.Date;
        }

        #endregion

        #region Nullable

        /// <summary>
        /// Retorna uma string formatada em PT-BR, ou "--" caso a instância seja nula
        /// </summary>
        /// <param name="date"></param>
        /// <returns>String contendo a data/hora formatada em PT-BR, ou "--" caso a data seja nula</returns>
        public static string ToStringPtBr(this DateTime? date)
        {
            return date.HasValue ? date.Value.ToStringPtBr() : "--";
        }

        /// <summary>
        /// Normaliza o horário da data para o início do dia (00:00:00), se a instância não for nula
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Data com o horário normalizado para o início do dia (00:00:00), se a instância não for nula</returns>
        public static DateTime? ToBeginDayTime(this DateTime? date)
        {
            // Normaliza apenas se houver data, senão retorna o próprio objeto
            return (date.HasValue ? date.Value.ToBeginDayTime() : date);
        }

        /// <summary>
        /// Normaliza o horário da data para o final do dia (23:59:59), se a instância não for nula
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Data com o horário normalizado para o fim do dia (23:59:59), se a instância não for nula</returns>
        public static DateTime? ToEndDayTime(this DateTime? date)
        {
            // Normaliza apenas se houver data, senão retorna o próprio objeto
            return (date.HasValue ? date.Value.ToEndDayTime() : date);
        }

        /// <summary>
        /// Seta o horário da data para um valor específico, se a instância não for nula
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hour">Hora a ser setada</param>
        /// <param name="minute">Minuto a ser setado</param>
        /// <param name="second">Segundo a ser setado</param>
        /// <returns>Data com o horário especificado, se a instância não for nula</returns>
        public static DateTime? ToSpecificTime(this DateTime? date, int hour, int minute, int second)
        {
            // Normaliza apenas se houver data, senão retorna o próprio objeto
            return (date.HasValue ? date.Value.ToSpecificTime(hour, minute, second) : date);
        }

        /// <summary>
        /// Garante que a instância de data seja compatível com o tipo DATETIME do Sql Server. Este tipo
        /// aceita apenas datas superiores à 1/1/1753.
        /// </summary>
        /// <param name="date">Instância da data a ser verificada</param>
        /// <returns>1/1/1753, caso a data da instância seja inferior à este valor, ou a própria data da instância, caso contrário.
        /// Se a instância for nula, não executa conversão e retorna o valor nulo</returns>
        public static DateTime? ToSqlServerCompatible(this DateTime? date)
        {
            // Verifica apenas se houver data, senão retorna o próprio objeto
            return (date.HasValue ? date.Value.ToSqlServerCompatible() : date);
        }

        /// <summary>
        /// Retorna a diferença em minutos entre duas datas, apenas se a data da instância for maior que
        /// a data do parâmetro. Caso contrário, ou caso alguma data for nula, a diferença retornada é zero
        /// </summary>
        /// <param name="date"></param>
        /// <param name="lowerDate">Data menor do que a data da instância</param>
        /// <returns>Se a data da instância não é nula e é maior que a data do parâmetro, retorna a diferença de minutos. Senão, retorna 0</returns>
        public static double TotalMinutesIfGreaterThan(this DateTime? date, DateTime? lowerDate)
        {
            if (!date.HasValue || !lowerDate.HasValue) return 0;
            return date.Value.TotalMinutesIfGreaterThan(lowerDate.Value);
        }

        /// <summary>
        /// Compara duas instâncias de data, ignorando a porção de horário
        /// </summary>
        /// <param name="date1">Data a ser comparada</param>
        /// <param name="date2">Data a ser comparada</param>
        /// <returns>As datas (sem horário) são iguais (true) ou não (false)</returns>
        public static bool EqualsIgnoreTime(this DateTime? date1, DateTime? date2)
        {
            // Se ambas as datas forem nulas, elas são iguais
            if (!date1.HasValue && !date2.HasValue) return true;

            // Se pelo menos uma delas for nula, não são iguais
            if (!date1.HasValue || !date2.HasValue) return false;

            // Compara as datas
            return date1.Value.EqualsIgnoreTime(date2.Value);
        }

        #endregion
    }
}
