using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Filters
{
    public class GlobalHeaderPageApplicationModelConvention : IPageApplicationModelConvention
    {
        public void Apply(PageApplicationModel model)
        {
            model.Filters.Add(new AddHeaderAttribute("Author", "Go"));
        }
    }
}
