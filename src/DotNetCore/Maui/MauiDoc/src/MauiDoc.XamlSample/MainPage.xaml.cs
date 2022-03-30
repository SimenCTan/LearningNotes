
namespace MauiDoc.XamlSample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
            CounterLabel.Text = $"Current count: {count}";

            SemanticScreenReader.Announce(CounterLabel.Text);
        }

        private void DragGestureRecognizer_DragStarting(object sender, DragStartingEventArgs e)
        {
        }
    }
}