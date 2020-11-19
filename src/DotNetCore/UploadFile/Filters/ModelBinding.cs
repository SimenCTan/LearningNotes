using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadFile.Filters
{
    public class DisableFormValueModelBindingAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var factories = context.ValueProviderFactories;
            factories.RemoveType<FormFileValueProviderFactory>();
            factories.RemoveType<FormValueProviderFactory>();
            factories.RemoveType<JQueryFormValueProviderFactory>();
        }
    }
}
