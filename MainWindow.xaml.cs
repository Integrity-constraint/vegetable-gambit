using Microsoft.Win32;
using System;
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
                    
                    Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*",
                    Title = "Выберите изображение"
                };

                if (folderDialog.ShowDialog() == true)
                {
                    var folderFile = folderDialog.FileName;
                    rootFile = folderFile;
                    path.Text = rootFile;

                  
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(rootFile);
                    bitmap.EndInit();
                    img.Source = bitmap;
                }
                else
                {
                  
                    return;
                }

                if (!File.Exists(rootFile))
                {
                    MessageBox.Show("Выбранный файл не существует.");
                    return;
                }
                ClassificationAsynSpecialForZuevAndrewCamelCaseCanGoFuckItself(rootFile, predict);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

          
        }


        async void ClassificationAsynSpecialForZuevAndrewCamelCaseCanGoFuckItself(string root, Label predict)
        {
            await Task.Run(() =>
            {
                var imageBytes = File.ReadAllBytes(root);
                ОвощнойГамбит.ModelInput simpleData = new ОвощнойГамбит.ModelInput()
                {
                    ImageSource = imageBytes,
                };
                var result = ОвощнойГамбит.Predict(simpleData);
                predict.Content = result.PredictedLabel;
            });
           Close();
        }
    }
}