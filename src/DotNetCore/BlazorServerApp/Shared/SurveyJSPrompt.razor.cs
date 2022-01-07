using System;
using Microsoft.AspNetCore.Components;
using BlazorServerApp.JsExamples;

namespace BlazorServerApp.Shared
{
    public partial class SurveyJSPrompt : ComponentBase, IObserver<ElementReference>, IDisposable
    {
        private IDisposable? subscription = null;

        [Parameter]
        public IObservable<ElementReference>? Parent { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            subscription?.Dispose();
            subscription = Parent != null ? Parent.Subscribe(this) : null;
        }

        public void OnCompleted()
        {
            subscription = null;
        }

        public void OnError(Exception ex)
        {
            subscription = null;
        }

        public void OnNext(ElementReference value)
        {
            JS.InvokeAsync<object>(
                    "setElementClass", new object[] { value, "red" });
        }

        public void Dispose()
        {
            subscription?.Dispose();
        }
    }
}
