using whizzy_software_media_organiser_LM.Models;

namespace whizzy_software_media_organiser_LM.Interfaces
{
    public interface IDataSource
    {
        void DeleteCategory(int categoryID);
        void DeletePlaylist(int playlistID);
        void LoadCategories(List<Category> categories);
        void LoadPlaylists(List<Playlist> allPlaylists);
        void SaveCategories(List<Category> categories);
        void SavePlaylist(Playlist playlist);
    }
}