using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiDoc.XamlSample.MarkupExtensions;

internal class HslColorExtension : IMarkupExtension<Color>
{
    public float H { get; set; }
    public float S { get; set; }
    public float L { get; set; }
    public float A { get; set; } = 1.0f;
    public Color ProvideValue(IServiceProvider serviceProvider)
    {
        return Color.FromHsla(H, S, L, A);
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
    {
        return (this as IMarkupExtension<Color>).ProvideValue(serviceProvider);
    }
}

