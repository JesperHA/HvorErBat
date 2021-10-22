using HvorErBat.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HvorErBat.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}