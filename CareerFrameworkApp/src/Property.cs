using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerFrameworkApp.src
{   
    [Serializable]
    public class property
    {
        public string name { get; set; }
        public List<option> option { get; set; }
    }
}
