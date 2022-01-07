using System.Threading.Tasks;
using Microsoft.JSInterop;

public class JsInteropClasses1
{
    private readonly IJSRuntime js;
    public JsInteropClasses1(IJSRuntime jSRuntime)
    {
        js = jSRuntime;
    }

    public async ValueTask TickerChange(string symbol, decimal price)
    {
        await js.InvokeVoidAsync("displayTickerAlert1", symbol, price);
    }

    public void Dispose()
    {

    }
}
