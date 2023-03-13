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
        private JsonDataStore _jsonDataStoreConfig;

        public JsonDataStoreService()
        {
            _jsonDataStoreConfig = new JsonDataStore();

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
            //line 34: will Serialize the parsed playlist object into JSON format
            var playlistJsonToWrite = JsonConvert.SerializeObject(playlist, Formatting.Indented);

            string filePath = Path.Combine(Path.Combine(_jsonDataStoreConfig.SavedPlaylistsDirectory), playlist.PlayListID + ".json");

            //line 40 - 42: create an instance of StreamWriter and write the Serialized playlist object to the filePath
            //using will dispose of the writer object once the operation is complete
            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(playlistJsonToWrite);
            }
        }

        public void LoadPlaylists(List<Playlist> allPlaylists)
        {
            //GetFiles method will get all playlist Json files from SavedPlaylists directory
            var savedPlaylists = Directory.GetFiles(_jsonDataStoreConfig.SavedPlaylistsDirectory);

            //line 52 - 61 will loop through each playlist json file in savedPlaylists string array and Deserialize into Playlist object and add playlist to allPlaylists.
            foreach (var playlist in savedPlaylists)
            {
                string playlistJsonFile;

                using (var reader = new StreamReader(playlist))
                {
                    playlistJsonFile = reader.ReadToEnd();
                    var savedPlaylist = JsonConvert.DeserializeObject<Playlist>(playlistJsonFile);

                    allPlaylists.Add(savedPlaylist);
                }
            }
        }

        public void DeletePlaylist(int playlistID)
        {
            string filePath = Path.Combine(_jsonDataStoreConfig.SavedPlaylistsDirectory, $"{playlistID}.json");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                throw new FileNotFoundException($"File path not found: {filePath}");
            }
        }
    }
}
