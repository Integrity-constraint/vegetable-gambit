using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObjectClassificationVegie
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

        private void classify(object sender, RoutedEventArgs e)
        {
            try
            {
                string rootFile = "";
                var folderDialog = new OpenFileDialog
                {
                    // дополнительные приколы
                };

                if (folderDialog.ShowDialog() == true)
                {
                    var folderFile = folderDialog.FileName;
                    rootFile = folderFile;
                    path.Text = rootFile;
                  
                }

                var imageBytes = File.ReadAllBytes(path.Text);
                ОвощнойГамбит.ModelInput simpleData = new ОвощнойГамбит.ModelInput()
                {
                    ImageSource = imageBytes,
                };
                var result = ОвощнойГамбит.Predict(simpleData);
                predict.Content = result.PredictedLabel;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(e.ToString());
            }
           

        }
    }
}