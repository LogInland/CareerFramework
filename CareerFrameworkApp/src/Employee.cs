using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerFrameworkApp.src
{
    [Serializable]
    public class Employee
    {
        public List<property> property { get; set; }       
    }
}
