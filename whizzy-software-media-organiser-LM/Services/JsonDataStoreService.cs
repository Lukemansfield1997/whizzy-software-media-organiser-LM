using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whizzy_software_media_organiser_LM.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            _jsonDataStoreConfig.SavedCategoriesDirectory = Path.Combine(_jsonDataStoreConfig.ApplicationDirectoryPath, "SavedCategories");

            //Code will check if the application contains the playlists directory or categories directory
            //If false it will createDirectory using savedPlaylists or savedCategories property name and path
            if (!Directory.Exists(_jsonDataStoreConfig.SavedPlaylistsDirectory))
            {
                Directory.CreateDirectory(_jsonDataStoreConfig.SavedPlaylistsDirectory);
            }

            if (!Directory.Exists(_jsonDataStoreConfig.SavedCategoriesDirectory))
            {
                Directory.CreateDirectory(_jsonDataStoreConfig.SavedCategoriesDirectory);
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
        }

        public void SaveCategories(List<Category> categories)
        {
            var jsonToWrite = JsonConvert.SerializeObject(categories, Formatting.Indented);

            string filePath = Path.Combine(Path.Combine(_jsonDataStoreConfig.SavedCategoriesDirectory), "Categories.json");

            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(jsonToWrite);

            }
        }

        public void LoadCategories(List<Category> categories)
        {
            string categoryFilePath = Path.Combine(_jsonDataStoreConfig.SavedCategoriesDirectory, "Categories.json");

            if (File.Exists(categoryFilePath))
            {
                using (var reader = new StreamReader(categoryFilePath))
                {
                    string catJsonFile = reader.ReadToEnd();
                    var savedCategories = JsonConvert.DeserializeObject<List<Category>>(catJsonFile);

                    categories.AddRange(savedCategories);
                }             
            }
        }

        public void DeleteCategory(int categoryID)
        {
            //read categories json file, deserialise into JSON object and check if categoryID is in the object deserilased.
            //if true, delete object and reserialise list back into JSON object and write to category file path

            string catFilePath = Path.Combine(_jsonDataStoreConfig.SavedCategoriesDirectory, "Categories.json");

            if (File.Exists(catFilePath))
            {
                string catJsonFile = File.ReadAllText(catFilePath);
                var catList = JsonConvert.DeserializeObject<List<Category>>(catJsonFile);

                //create new list of categories to avoid System.InvalidOperationException: 'Collection was modified error.
                List<Category> newcategoriesList = new List<Category>();

                foreach (var cat in catList)
                {
                    //if categories do not equal same ID as parsed category to delete, add to new list of categories
                    if (cat.CategoryID != categoryID)
                    {
                        newcategoriesList.Add(cat);
                    }
                }

                //Serialise new list of categories into JSON object and write file to categories path
                var jsonToWrite = JsonConvert.SerializeObject(newcategoriesList, Formatting.Indented);

                using (var writer = new StreamWriter(catFilePath))
                {
                    writer.Write(jsonToWrite);
                }
            }
        }
    }
}
