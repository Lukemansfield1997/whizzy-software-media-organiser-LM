using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whizzy_software_media_organiser_LM.Models
{
    public class Playlist
    {
        public int PlayListID { get; set; }
        public string PlayListName { get; set; }
        public List<MediaItem> MediaFileItems { get; set; } = new List<MediaItem>();

    }
}
