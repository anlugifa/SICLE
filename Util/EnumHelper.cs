using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace Util
{

    public static class EnumHelper
    {
        static EnumHelper()
        {
            // var enumType = typeof(T);
            // if (!enumType.IsEnum) { throw new ArgumentException("Type '" + enumType.Name + "' is not an enum"); }
        }

        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public static string GetEnumDescription<TEnum>(TEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if ((attributes != null) && (attributes.Length > 0))
                return attributes[0].Description;
            else
                return value.ToString();
        }


        public static IEnumerable<SelectListItem> GetSelectList<T>()
        {
            var groupDictionary = new Dictionary<string, SelectListGroup>();

            var enumType = typeof(T);
            var fields = from field in enumType.GetFields()
                         where field.IsLiteral
                         select field;

            var list = new List<SelectListItem>();
            foreach (var field in fields)
            {
                var display = field.GetCustomAttribute<DisplayAttribute>(false);
                var description = field.GetCustomAttribute<DescriptionAttribute>(false);
                var group = field.GetCustomAttribute<CategoryAttribute>(false);

                var text = display?.GetName() ?? display?.GetShortName() ?? display?.GetDescription() ?? display?.GetPrompt() ?? description?.Description ?? field.Name;
                var value = field.Name;
                var groupName = display?.GetGroupName() ?? group?.Category ?? string.Empty;
                if (!groupDictionary.ContainsKey(groupName))
                {
                    groupDictionary.Add(groupName, new SelectListGroup { Name = groupName });
                }

                if (String.IsNullOrEmpty(groupName))
                {
                    list.Add(new SelectListItem
                    {
                        Text = text,
                        Value = value
                    });
                }
                else
                {
                    list.Add(new SelectListItem
                    {
                        Text = text,
                        Value = value,
                        Group = groupDictionary[groupName],
                    });
                }
            }

            return list.OrderBy(p => p.Text);
        }

        public static IHtmlContent EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper,
                    Expression<Func<TModel, TEnum>> expression)
        {
            return EnumDropDownListFor(htmlHelper, expression, null);
        }

        public static IHtmlContent EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper,
                            Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
        {
            var metadata = ExpressionMetadataProvider.FromLambdaExpression(expression, htmlHelper.ViewData, htmlHelper.MetadataProvider);
            Type enumType = GetNonNullableModelType(metadata);
            IEnumerable<TEnum> values = Enum.GetValues(enumType).Cast<TEnum>();

            IEnumerable<SelectListItem> items = from value in values
                                                select new SelectListItem
                                                {
                                                    Text = GetEnumDescription(value),
                                                    Value = value.ToString(),
                                                    Selected = value.Equals(metadata.Model)
                                                };

            return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
        }

        private static Type GetNonNullableModelType(ModelExplorer modelMetadata)
        {
            Type realModelType = modelMetadata.ModelType;

            Type underlyingType = Nullable.GetUnderlyingType(realModelType);
            if (underlyingType != null)
            {
                realModelType = underlyingType;
            }
            return realModelType;
        }
    }
}