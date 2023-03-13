using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whizzy_software_media_organiser_LM.Models;

namespace whizzy_software_media_organiser_LM.Services
{
    public class JsonDataStoreService
    {
        private JSONDataStore _jsonDataStoreConfig;

        public JsonDataStoreService()
        {
            _jsonDataStoreConfig = new JSONDataStore();

            //Will get current working directory path and save this to the ApplicationDirectoryPath property
            _jsonDataStoreConfig.ApplicationDirectoryPath = Directory.GetCurrentDirectory();
            _jsonDataStoreConfig.SavedPlaylistsDirectory = Path.Combine(_jsonDataStoreConfig.ApplicationDirectoryPath, "SavedPlaylists");

            //Code will check if the application contains the playlists directory
            //If false it will createDirectory using savedPlaylists property name and path
            if (!Directory.Exists(_jsonDataStoreConfig.SavedPlaylistsDirectory))
            {
                Directory.CreateDirectory(_jsonDataStoreConfig.SavedPlaylistsDirectory);
            }
        }

        public void SavePlaylists(Playlist playlist)
        {
            var jsonToWrite = JsonConvert.SerializeObject(playlist, Formatting.Indented);

            string filePath = Path.Combine(Path.Combine(_jsonDataStoreConfig.SavedPlaylistsDirectory), playlist.PlayListID + ".json");

            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(jsonToWrite);

            }
        }
    }
}
