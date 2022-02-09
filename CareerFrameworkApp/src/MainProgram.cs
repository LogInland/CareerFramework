using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;

namespace CareerFrameworkApp.src
{
    public class MainProgram
    {
        private async Task<StorageFile> findFile()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            openPicker.FileTypeFilter.Add(".json");

            return await openPicker.PickSingleFileAsync();
        }

        public string LoadJson(string path)
        {            
            using (StreamReader r = new StreamReader(path))
            {
                return r.ReadToEnd();                               
            }
        }

        public Employee getEmployee()
        {            
            StorageFile file = findFile().Result;
            return deserializeEmployee(LoadJson(file.Path));
        }

        private Employee deserializeEmployee(String json)
        {
            Employee employee = new Employee();

            try
            {
                employee = JsonConvert.DeserializeObject<Employee>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return employee;
        }
    }
}
