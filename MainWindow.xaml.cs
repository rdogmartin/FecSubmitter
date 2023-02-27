using System.Windows;

namespace FecSubmitter
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void btnSelectFecFile_Click(object sender, RoutedEventArgs e)
		{
			var dialog = new Microsoft.Win32.OpenFileDialog
			{
				FileName = "Document",
				DefaultExt = ".fec",
				Filter = "Text documents (.fec)|*.fec"
			};

			var result = dialog.ShowDialog();

			// Process open file dialog box results
			if (result == true)
			{
				// Open document
				var filename = dialog.FileName;
				lblFecFilePath.Content = filename;
			}
		}

		private async void btnSubmitFecFile_Click(object sender, RoutedEventArgs e)
		{
			var fecFilePath = lblFecFilePath.Content.ToString();

			if (!string.IsNullOrWhiteSpace(fecFilePath))
			{
				var fecSubmissionService = new FecSubmissionService();

				await FecSubmissionService.SubmitFecFile(fecFilePath);
			}
		}
    }
}
