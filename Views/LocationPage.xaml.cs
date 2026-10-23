using WhereIAmPage.ViewModels;

namespace WhereIAmPage.Views;

public partial class LocationPage : ContentPage
{
	public LocationPage(LocationViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}