using CareerFrameworkApp.src;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CareerFrameworkApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void addToGridTextBox(string text, int row, int column)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.FontSize = 30;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.Text = text;
            Grid.SetRow(textBlock, row);
            Grid.SetColumn(textBlock, column);
            mainGrid.Children.Add(textBlock);
        }

        private void addToGridOptionComboBox(property property, int row, int column)
        {
            ComboBox comboBox = new ComboBox();
            foreach (option option in property.option)
            {
                comboBox.Items.Add(option.Title);
            }
            comboBox.VerticalAlignment = VerticalAlignment.Center;
            comboBox.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(comboBox, row);
            Grid.SetColumn(comboBox, column);
            mainGrid.Children.Add(comboBox);
        }

        private async void loadFile_Click(object sender, RoutedEventArgs e)
        {
            
            MainProgram program = new MainProgram();
            Employee employee = await program.getEmployee();

            int row = 3;
            foreach(property property in employee.property)
            {
                addToGridTextBox(property.name, row, 0);
                addToGridTextBox("Empty", row, 1);
                addToGridOptionComboBox(property, row, 2);
                row++;
            }

                      
        }
    }
}
