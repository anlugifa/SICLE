using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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

        // public static IEnumerable<SelectListItem> GetSelectList()
        // {
        //     var groupDictionary = new Dictionary<string, SelectListGroup>();

        //     var enumType = typeof(T);
        //     var fields = from field in enumType.GetFields()
        //                  where field.IsLiteral
        //                  select field;

        //     foreach (var field in fields)
        //     {
        //         var display = field.GetCustomAttribute<DisplayAttribute>(false);
        //         var description = field.GetCustomAttribute<DescriptionAttribute>(false);
        //         var group = field.GetCustomAttribute<CategoryAttribute>(false);

        //         var text = display?.GetName() ?? display?.GetShortName() ?? display?.GetDescription() ?? display?.GetPrompt() ?? description?.Description ?? field.Name;
        //         var value = field.Name;
        //         var groupName = display?.GetGroupName() ?? group?.Category ?? string.Empty;
        //         if (!groupDictionary.ContainsKey(groupName)) { groupDictionary.Add(groupName, new SelectListGroup { Name = groupName }); }

        //         yield return new SelectListItem
        //         {
        //             Text = text,
        //             Value = value,
        //             Group = groupDictionary[groupName],
        //         };
        //     }
        // }
    }
}