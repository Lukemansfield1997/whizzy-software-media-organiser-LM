using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using whizzy_software_media_organiser_LM.Models;

namespace whizzy_software_media_organiser_LM.Services
{
    public class PlaylistService
    {
        private List<Playlist> _allPlaylists;
        private JsonDataStoreService _jsonDataStoreService;

        public PlaylistService()
        {
            _allPlaylists = new List<Playlist>();
            _jsonDataStoreService = new JsonDataStoreService(); 
        }

        public Playlist CreatePlaylist(string playlistName)
        {
            var newPlaylist = new Playlist
            {
                PlayListID = _allPlaylists.Count,
                PlayListName = playlistName,
            };

            _allPlaylists.Add(newPlaylist);

            return newPlaylist;
        }

        public Playlist GetPlayListById(int id)
        {
            // will iterate through allPlaylists, find a playlist that matches the playlist id parsed
            // and return the playlist to the user
            return _allPlaylists.SingleOrDefault(i => i.PlayListID == id);
        }

        public List<Playlist> GetPlayLists()
        {
            // returns allPlaylists that have been created
            return _allPlaylists;
        }

        public void RenamePlaylist(Playlist playlist, string playlistName)
        {
           playlist.PlayListName = playlistName;
        }

        public void SavePlaylist(Playlist playlist)
        {
          _jsonDataStoreService.SavePlaylists(playlist);    
        }

        public void DeletePlaylist(int Id)
        {
          _allPlaylists.Remove(GetPlayListById(Id));

        }

    }
}
