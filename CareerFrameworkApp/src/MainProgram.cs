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

        public async Task<Employee> getEmployee()
        {            
            StorageFile file = await findFile();
            string fileString;
            var stream = await file.OpenReadAsync();
            using (StreamReader reader = new StreamReader(stream.AsStream()))
            {
                fileString = reader.ReadToEnd();
            }
            
            return deserializeEmployee(fileString);
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
