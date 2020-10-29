using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.PageModels
{
    public class Index2Model:PageModel
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly PositionOptions _positionOptions;
        public Index2Model(IConfiguration configurationRoot,
            IOptions<PositionOptions> options)
        {
            _configurationRoot =(IConfigurationRoot) configurationRoot;
            _positionOptions = options.Value;
        }

        public ContentResult OnGet()
        {
            var str = "";
            foreach (var provider in _configurationRoot.Providers.ToList())
            {
                str += provider.ToString() + "\n";
            }
            return Content(str);
        }
    }
}
