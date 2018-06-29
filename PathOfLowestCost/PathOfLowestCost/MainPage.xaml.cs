using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using PathOfLowestCost.ViewModels;
using Xamarin.Forms;

namespace PathOfLowestCost
{
	public partial class MainPage : ContentPage
	{
	    private readonly MainPageViewModel _vm;
		public MainPage()
		{
            _vm = new MainPageViewModel();
		    BindingContext = _vm;
			InitializeComponent();
		    SetupPage();

		}

	    public void SetupPage()
	    {
         //   var input = new Entry();
	        //input.SetBinding(Entry.TextProperty, "MatrixData");
         //   input.HorizontalOptions = LayoutOptions.CenterAndExpand;
         //   var findButton = new Button{Text = "Find Lowest"};
         //   findButton.Clicked += FindButtonOnClicked;
         //   findButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
            
	        //Content = new StackLayout
	        //{
         //       VerticalOptions  = LayoutOptions.FillAndExpand,
         //       Padding = new Thickness(30),
         //       Children = { input, findButton}
	        //};
        }

	    private async void Button_OnClicked(object sender, EventArgs e)
	    {
	        await _vm.GetAsync();
        }
	}
}
