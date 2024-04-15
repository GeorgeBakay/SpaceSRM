namespace SpaceSRM;

public partial class MainPage : ContentPage
{
	int count = -10;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count += 5;
		Hello.Text = "Good bye";
		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";
		SemanticScreenReader.Announce(Hello.Text);
		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

