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

        private void loadFile_Click(object sender, RoutedEventArgs e)
        {
            
            MainProgram program = new MainProgram();
            Employee employee = program.getEmployee();
            ComboBox comboBox = new ComboBox();
            comboBox.Items.Add(employee.property.First().name);
            comboBox.Items.Add(employee.property.Last().name);
            Grid.SetRow(comboBox, 3);
            Grid.SetColumn(comboBox, 1);
            mainGrid.Children.Add(comboBox);


            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Gabumai";
            Grid.SetRow(textBlock, 3);
            Grid.SetColumn(textBlock, 0);
            mainGrid.Children.Add(textBlock);
        }
    }

    class BreadLMAO
    {
        public static void runShit(Action shitToDo)
        {
            new Thread(() =>
            {
                shitToDo();
            }).Start();
        }
    }
}
