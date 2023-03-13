﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using whizzy_software_media_organiser_LM.Models;

namespace whizzy_software_media_organiser_LM.Services
{
    public class PlaylistServiceJsonDataStore
    {
        private List<Playlist> _allPlaylists;
        private JsonDataStoreService _jsonDataStoreService;

        public PlaylistServiceJsonDataStore()
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

        public Playlist GetPlayListById(int playlistID)
        {
            // will iterate through allPlaylists, find a playlist that matches the playlist id parsed
            // and return the playlist to the user
            return _allPlaylists.SingleOrDefault(i => i.PlayListID == playlistID);
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

        public void LoadPlaylists()
        {
          _jsonDataStoreService.LoadPlaylists(_allPlaylists);
        }

        public void SavePlaylist(Playlist playlist)
        {
          _jsonDataStoreService.SavePlaylists(playlist);    
        }

        public void DeletePlaylist(int playlistID)
        {
          _allPlaylists.Remove(GetPlayListById(playlistID));
          _jsonDataStoreService.DeletePlaylist(playlistID);
        }

        public void AddMediaFileToPlaylist(int playlistID, string mediaFile)
        {
            var selectedPlaylist = GetPlayListById(playlistID);

            selectedPlaylist.MediaFileItems.Add(new MediaItem
            {
                Song = Path.GetFileNameWithoutExtension(mediaFile),
                FilePath = Path.GetFullPath(mediaFile),
                FileType = Path.GetExtension(mediaFile)
            });
        }
    }
}