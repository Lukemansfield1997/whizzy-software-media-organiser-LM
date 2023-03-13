using whizzy_software_media_organiser_LM.Services;

namespace whizzy_software_media_organiser_Tests
{
    public class PlaylistTests
    {
        PlaylistService _playlistService;
        [SetUp]
        public void Setup()
        {
            _playlistService = new PlaylistService();
        }

        [Test]
        public void PlaylistIsCreated()
        {
            //Arrange
            string playlistName = "new playlist";

            //Act
            _playlistService.CreatePlaylist(playlistName);

            //Assert
            Assert.That(1, Is.EqualTo(_playlistService.GetPlayLists().Count));
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
            Assert.That(0, Is.EqualTo(_playlistService.GetPlayLists().Count));
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
            Assert.That(createdPlaylist.PlayListName, Is.EqualTo(newPlaylistName));
        }
    }
}