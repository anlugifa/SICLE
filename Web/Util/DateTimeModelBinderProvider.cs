using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Sicle.Web.Util
{

    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(DateTime) ||
                context.Metadata.ModelType == typeof(DateTime?))
            {
                return new DateTimeModelBinder();
            }

            return null;
        }
    }

    public class DateTimeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));           

            var modelName = GetModelName(bindingContext);

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            var auxValueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName+".O");
            if (valueProviderResult == ValueProviderResult.None ||
                auxValueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var dateToParse = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(dateToParse))
            {
                return Task.CompletedTask;
            }

            var dateTime = ParseDate(bindingContext, dateToParse);

            bindingContext.Result = ModelBindingResult.Success(dateTime);

            return Task.CompletedTask;
        }

        private string GetModelName(ModelBindingContext bindingContext)
        {
            // The "Name" property of the ModelBinder attribute can be used to specify the
            // route parameter name when the action parameter name is different from the route parameter name.
            // For instance, when the route is /api/{birthDate} and the action parameter name is "date".
            // We can add this attribute with a Name property [DateTimeModelBinder(Name ="birthDate")]
            // Now bindingContext.BinderModelName will be "birthDate" and bindingContext.ModelName will be "date"
            if (!string.IsNullOrEmpty(bindingContext.BinderModelName))
            {
                return bindingContext.BinderModelName;
            }

            return bindingContext.ModelName;
        }

        private DateTime? ParseDate(ModelBindingContext bindingContext, string dateToParse)
        {
            var attribute = GetDateTimeModelBinderAttribute(bindingContext);
            var dateFormat = attribute?.DateFormat;

            DateTime date;

            if (!DateTime.TryParse(dateToParse, new CultureInfo("pt-BR"), DateTimeStyles.None, out date))
            {
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "DateTime should be in format 'dd/MM/yyyy HH:mm:ss'");                
            }   

            return date;
        }

        private DateTimeModelBinderAttribute GetDateTimeModelBinderAttribute(ModelBindingContext bindingContext)
        {
            var modelName = GetModelName(bindingContext);

            var paramDescriptor = bindingContext.ActionContext.ActionDescriptor.Parameters
                                    .Where(x => x.ParameterType == typeof(DateTime?))
                                    .Where((x) =>
                                    {
                                        // See comment in GetModelName() on why we do this.
                                        var paramModelName = x.BindingInfo?.BinderModelName ?? x.Name;
                                        return paramModelName.Equals(modelName);
                                    })
                                    .FirstOrDefault();

            var ctrlParamDescriptor = paramDescriptor as ControllerParameterDescriptor;
            if (ctrlParamDescriptor == null)
            {
                return null;
            }

            var attribute = ctrlParamDescriptor.ParameterInfo
                .GetCustomAttributes(typeof(DateTimeModelBinderAttribute), false)
                .FirstOrDefault();

            return (DateTimeModelBinderAttribute)attribute;
        }
    }



    public class DateTimeModelBinderAttribute : ModelBinderAttribute
    {
        public string DateFormat { get; set; }

        public DateTimeModelBinderAttribute()
            : base(typeof(DateTimeModelBinder))
        {
        }
    }
}