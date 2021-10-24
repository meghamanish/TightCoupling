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
using PeopleViewer.Presentation;

namespace PeopleViewer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		PeopleViewModel viewModel;
		public MainWindow(PeopleViewModel model)
		{
			InitializeComponent();
			viewModel = model;
			this.DataContext = viewModel;
		}

		private void FetchButton_Click(object sender, RoutedEventArgs e)
		{
			viewModel.RefreshPeople();
			ShowRepositoryType();
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			viewModel.ClearPeople();
			ClearRepositoryType();
		}

		private void ShowRepositoryType()
		{
			RepositoryTypeTextBlock.Text = viewModel.DataReaderType;
		}

		private void ClearRepositoryType()
		{
			RepositoryTypeTextBlock.Text = string.Empty;
		}
  }
}
