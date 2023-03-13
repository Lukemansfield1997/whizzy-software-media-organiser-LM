using whizzy_software_media_organiser_LM.Services;

namespace whizzy_software_media_organiser_Tests
{
    public class PlaylistTests
    {
        PlaylistServiceJsonDataStore _playlistService;
        [SetUp]
        public void Setup()
        {
            _playlistService = new PlaylistServiceJsonDataStore();
        }

        [Test]
        public void PlaylistIsCreated()
        {
            //Arrange
            string playlistName = "new playlist";

            //Act
            _playlistService.CreatePlaylist(playlistName);

            //Assert
            Assert.That(_playlistService.GetPlayLists().Count, Is.EqualTo(1));
        }
        

        [Test]
        public void PlaylistIsDeleted()
        {
            //Arrange
            string playlistName = "new playlist";

            //Act
           var createdPlaylist = _playlistService.CreatePlaylist(playlistName);
            _playlistService.DeletePlaylist(createdPlaylist.PlayListID);

            //Assert
            Assert.That(_playlistService.GetPlayLists().Count, Is.EqualTo(0));
        }

        [Test]
        public void PlaylistIsRenamed()
        {

            //Arrange
            string playlistName = "new playlist";
            string newPlaylistName = "playlist renamed";

            //Act
            var createdPlaylist = _playlistService.CreatePlaylist(playlistName);
            _playlistService.RenamePlaylist(createdPlaylist, newPlaylistName);

            //Assert
            Assert.That(newPlaylistName, Is.EqualTo(createdPlaylist.PlayListName));
        }
    }
}