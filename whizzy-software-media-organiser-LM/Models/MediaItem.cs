using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whizzy_software_media_organiser_LM.Models
{
    public class MediaItem
    {
        public string Song { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string MediaImageName { get; set; }
        public string MediaImagePath { get; set; }
        public List<Category> CategoriesList { get; set; } = new List<Category>();
        public string Comment { get; set; }

    }
}
