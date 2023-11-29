namespace NET8MAUIApp
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
            if (count == 1)
            {
                CounterBtn.Text = $"Clicked {count} time";
                tkEntry.IsEnabled = false;
            }
            else if (count == 2)
            {
                CounterBtn.Text = $"Clicked {count} times";
                tkEntry.IsEnabled = true;
            }
            else
            {
                CounterBtn.Text = $"Clicked {count} times";
                tkEntry.IsEnabled = false;
            }

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
