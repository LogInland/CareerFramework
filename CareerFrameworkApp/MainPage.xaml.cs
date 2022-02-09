using CareerFrameworkApp.src;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
            LoadJson();
        }

        public void LoadJson()
        {
            string fileName = "example.json";
            var path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
            Console.WriteLine(path);
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                deserialiseJSON(json);
                //List<Property> items = JsonConvert.DeserializeObject<List<Property>>(json);
            }
        }

        private void deserialiseJSON(string strJSON)
        {
            try
            {
                var jProperty = JsonConvert.DeserializeObject<Property>(strJSON);
                MessageDialog message = new MessageDialog("Tuscia");
                message.ShowAsync();
                //Console.WriteLine(jProperty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
