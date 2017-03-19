using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameLib.Wpf.ViewModels;
using Simpler.Net.Wpf;

namespace GameLib.Wpf {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly MainViewModel _viewModel;
		private readonly SimplerWindow _win;

		public MainWindow() {
			this._win = new SimplerWindow(this);
			this._win.FullyLoaded += this.WindowFullyLoaded;

			this.InitializeComponent();

			this._viewModel = new MainViewModel();

			this.DataContext = this._viewModel;
		}

		private void WindowFullyLoaded(Object sender, EventArgs e)
		{
			this._viewModel.ActivityText = "Loading Steam games...";
		}
	}
}
