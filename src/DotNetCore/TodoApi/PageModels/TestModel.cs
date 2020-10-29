using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.PageModels
{
    public class TestModel:PageModel
    {
        private readonly IConfiguration _configuration;
        public TestModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ContentResult OnGet()
        {
            // Bind positionOption
            var positionOption = new PositionOptions();
            _configuration.GetSection(PositionOptions.Position).Bind(positionOption);

            var positionOptionSelection = _configuration.GetSection(PositionOptions.Position);
            if (positionOptionSelection.Exists())
            {
                var children = positionOptionSelection.GetChildren();
            }

            // two
            var pitionOption = _configuration.GetSection(PositionOptions.Position).Get<PositionOptions>();

            var mykeyValue = _configuration["MyKey"];
            var title = _configuration["Position:Title"];
            var name = _configuration["Position:Name"];
            var defaultLogLevel = _configuration["Logging:LogLevel:Default"];
            return Content($"MyKey value: {mykeyValue} \n" +
                           $"Title: {title} \n" +
                           $"Name: {name} \n" +
                           $"Default Log Level: {defaultLogLevel}");
        }
    }
}
