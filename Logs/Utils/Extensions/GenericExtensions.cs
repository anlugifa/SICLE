using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

using Newtonsoft.Json;
using Sicle.Logs.Utils.CustomAnnotation;

namespace Sicle.Logs.Extensions
{
    public static class GenericsExtensions
    {
        /// <summary>
        /// Realiza um Deep Copy do objeto, usando serialização Json.
        /// IMPORTANTE: atributos privados NÃO serão copiados para o objeto clonado.
        /// Este método depende do componente Newtonsoft.Json, que deve ser referenciado
        /// no projeto que está fazendo uso desta extensão
        /// </summary>
        /// <typeparam name="T">Tipo do objeto a ser clonado</typeparam>
        /// <param name="source">Instância do objeto a ser clonado</param>
        /// <returns>Clone do objeto</returns>
        public static T Clone<T>(this T source) where T : class
        {
            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            // initialize inner objects individually
            // for example in default constructor some list property initialized with some values,
            // but in 'source' these items are cleaned -
            // without ObjectCreationHandling.Replace default constructor values will be added to result
            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), deserializeSettings);
        }

        /// <summary>
        /// Realiza a comparação dos valores de todas as propriedades públicas de dois objetos.
        /// IMPORTANTE: propriedades privadas e protegidas NÃO serão comparadas. Este método depende
        /// do componente Newtonsoft.Json, que deve ser referenciado no projeto que está fazendo uso
        /// desta extensão
        /// </summary>
        /// <typeparam name="T">Tipo dos objetos que serão comparados</typeparam>
        /// <param name="source">Instância do objeto de origem</param>
        /// <param name="other">Instância do objeto a ser comparado</param>
        /// <returns>Flag indicando se os valores de propriedade dos objetos são iguais (true) ou não (false)</returns>
        public static bool CompareProperties<T>(this T source, T other) where T : class
        {
            // Objetos nulos não são comparáveis
            if (null == source) return false;
            if (null == other) return false;

            // Possuem a mesma referência?
            if (object.ReferenceEquals(source, other)) return true;

            // Comparamos as propriedades e seus respectivos valores através de serialização Json
            return JsonConvert.SerializeObject(source).Equals(JsonConvert.SerializeObject(other));
        }

        /// <summary>
        /// Verifica se um Type possui um atributo de um determinado tipo
        /// </summary>
        /// <typeparam name="T">Tipo do atributo a ser verificado</typeparam>
        /// <param name="source">Instância do objeto de origem das informações</param>
        /// <returns>A instância possui um atributo do tipo verificado (true) ou não (false)</returns>
        public static bool HasMarkerAttribute<T>(this Type source) where T : Attribute
        {
            if (source == null) return false;
            return source.GetCustomAttributes<T>().Any();
        }

        /// <summary>
        /// Obtém uma lista de atributos customizados de um determinado Type
        /// </summary>
        /// <typeparam name="T">Tipo do atributo a ser verificado</typeparam>
        /// <param name="source">Instância do objeto de origem das informações</param>
        /// <returns>Lista de atributos customizados do tipo especificado</returns>
        public static IEnumerable<T> GetCustomAttributes<T>(this Type source) where T : Attribute
        {
            if (source == null) return default(IEnumerable<T>);
            return source.GetCustomAttributes(typeof(T), false).Cast<T>();
        }

        /// <summary>
        /// Obtém o atributo de uma propriedade de um determinado objeto
        /// </summary>
        /// <typeparam name="TObject">Tipo do objeto</typeparam>
        /// <typeparam name="TAttribute">Tipo do atributo</typeparam>
        /// <typeparam name="TProperty">Tipo da propriedade</typeparam>
        /// <param name="source">Instância do objeto</param>
        /// <param name="property">Expressão para busca da propriedade</param>
        /// <returns>Atributo solicitado, ou null caso não seja encontrado</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA1801:ReviewUnusedParameters",
            MessageId = "source",
            Justification ="A instância do objeto não é utilizada neste método de extensão, apenas seu tipo. Ela foi incluída apenas para prover a comodidade de usar o método como uma extensão de qualquer objeto genérico"
        )]
        public static TAttribute GetCustomAttribute<TObject, TAttribute, TProperty>(this TObject source, Expression<Func<TObject, TProperty>> property) 
        {
            if (property != null)
            {
                // Resolve nome da propriedade a partir da expressão recebida
                var nomePropriedade = property.Body.ToStringOrEmpty();

                // Expressão resultou em uma propriedade válida?
                if (!nomePropriedade.IsNullOrWhiteSpace())
                {
                    // Busca a propriedade no objeto
                    var propriedade = typeof(TObject).GetProperty(nomePropriedade);

                    // Propriedade encontrada?
                    if (propriedade != null)
                    {
                        // Busca os atributos da propriedade
                        var atributos = propriedade.GetCustomAttributes(false);

                        // Existem atributos definidos na propriedade?
                        if (atributos != null)
                        {
                            // Itera sobre todos os atributos encontrados
                            foreach (var atributo in atributos)
                            {
                                // Se o tipo do atributo é o tipo desejado, retorna
                                if (atributo is TAttribute)
                                    return (TAttribute)atributo;
                            }
                        }
                    }
                }
            }

            // Se chegou neste ponto, não encontramos o que desejávamos
            return default(TAttribute);
        }

        /// <summary>
        /// Garante que todas as propriedades dop tipo string marcadas com o atributo StringLengthRaizen
        /// e o flag TruncateIfStringLengthExceeded setado para "true" sejam devidamente truncadas
        /// </summary>
        /// <typeparam name="T">Tipo do objeto de origem das informações</typeparam>
        /// <param name="source">Instância do objeto de origem das informações</param>
        /// <returns></returns>
        public static T EnsureStringMaxLength<T>(this T source) where T : class
        {
            var type = typeof(StringLengthRaizen);

            // Obtém todas as propriedades que possuem o atributo StringLengthRaizen definido
            var properties = source.GetType().GetProperties().Where(prop => prop.IsDefined(type, false));

            foreach (var prop in properties)
            {
                // Se definido, teremos apenas um atributo do tipo StringLengthRaizen, uma vez que este atributo
                // não permite múltiplas definições para um mesmo objeto. Sendo assim, é possível usar o método
                // FirstOrDefault para obter objeto do atributo
                var attribute = prop.GetCustomAttributes(type, true).FirstOrDefault() as StringLengthRaizen;

                if (attribute != null &&
                    // O flag de truncate está ativo?
                    attribute.TruncateIfStringLengthExceeded &&
                    // A propriedade é do tipo String?d
                    prop.PropertyType == typeof(string))
                {
                    var val = prop.GetValue(source, null) as string;
                    prop.SetValue(source, val.Truncate(attribute.MaximumLength), null);
                }
            }

            return source;
        }

        /// <summary>
        /// Injeta uma nova condição na expressão existente
        /// </summary>
        /// <typeparam name="T">Tipo do objeto da expressão</typeparam>
        /// <param name="currentConditions">Expressão atual</param>
        /// <param name="conditionToAdd">Nova condição a ser adicionada</param>
        /// <returns>Expressão contendo a condição atual + condição adicionada</returns>
        public static Expression<Func<T, bool>> InjectCondition<T>(this Expression<Func<T, bool>> currentConditions, Expression<Func<T, bool>> conditionToAdd) where T : class
        {
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(currentConditions, conditionToAdd), currentConditions.Parameters);
        }
    }
}