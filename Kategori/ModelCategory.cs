using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolanKuyDesktopPalingbaru.Kategori
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ModelCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class RootCategory
    {
        public List<ModelCategory> category { get; set; }
    }
}
