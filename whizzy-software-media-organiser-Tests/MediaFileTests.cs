using System.Drawing.Imaging;

namespace whizzy_software_media_organiser_Tests
{
    public class MediaFileTests
    {
        PlaylistServiceJsonDataStore _playlistService;
        [SetUp]
        public void Setup()
        {
            _playlistService = new PlaylistServiceJsonDataStore();
        }

        [Test]
        public void MediaFileIsAddedToPlaylist()
        {
            //Arrange
            string playlistName = "new playlist";
            string mediaFile = "C:\\Users\\Luke Mansfield\\Downloads\\sample.mp3";
            string mediafileWithoutExtension = Path.GetFileNameWithoutExtension(mediaFile);
            string mediaFileType = Path.GetExtension(mediaFile);

            var playlist = _playlistService.CreatePlaylist(playlistName);

            //Act
            _playlistService.AddMediaFileToPlaylist(playlist.PlayListID, mediaFile);
            //Assert
            Assert.That(playlist.MediaFileItems.Count, Is.EqualTo(1));
            Assert.That(playlist.MediaFileItems[0].Song, Is.EqualTo(mediafileWithoutExtension));
            Assert.That(playlist.MediaFileItems[0].FilePath, Is.EqualTo(mediaFile));
            Assert.That(playlist.MediaFileItems[0].FileType, Is.EqualTo(mediaFileType));
        }
        [Test]
        public void MediaFileImageIsAdded()
        {
            //Arrange
            string playlistName = "new playlist";
            string mediaFile = "C:\\Users\\Luke Mansfield\\Downloads\\sample.mp3";
            string mediaFileImagePath = "C:\\Users\\Luke Mansfield\\Downloads\\sample.jpg";
            string mediafileImageName = Path.GetFileNameWithoutExtension(mediaFileImagePath);

            var playlist = _playlistService.CreatePlaylist(playlistName);
            _playlistService.AddMediaFileToPlaylist(playlist.PlayListID, mediaFile);

            //Act
            _playlistService.AddMediaImage(playlist, 0, mediaFileImagePath, mediafileImageName);

            //Assert
            Assert.That(playlist.MediaFileItems[0].MediaImageName, Is.EqualTo(mediafileImageName));
            Assert.That(playlist.MediaFileItems[0].MediaImagePath, Is.EqualTo(mediaFileImagePath));
        }

        [Test]
        public void MediaFileImageIsDeleted()
        {
            //Arrange
            string playlistName = "new playlist";
            string mediaFile = "C:\\Users\\Luke Mansfield\\Downloads\\sample.mp3";
            string mediaFileImagePath = "C:\\Users\\Luke Mansfield\\Downloads\\sample.jpg";
            string mediafileImageName = Path.GetFileNameWithoutExtension(mediaFileImagePath);

            var playlist = _playlistService.CreatePlaylist(playlistName);
            _playlistService.AddMediaFileToPlaylist(playlist.PlayListID, mediaFile);
            _playlistService.AddMediaImage(playlist, 0, mediaFileImagePath, mediafileImageName);

            //Act
            _playlistService.DeleteMediaImage(playlist, 0);
            //Assert
            Assert.That(playlist.MediaFileItems[0].MediaImageName, Is.EqualTo(""));
            Assert.That(playlist.MediaFileItems[0].MediaImagePath, Is.EqualTo(""));
        }
        [Test]
        public void MediaFileCommentIsAdded()
        {
            //Arrange
            string playlistName = "new playlist";
            string mediaFile = "C:\\Users\\Luke Mansfield\\Downloads\\sample.mp3";
            string comment = "cool song";

            var playlist = _playlistService.CreatePlaylist(playlistName);
            _playlistService.AddMediaFileToPlaylist(playlist.PlayListID, mediaFile);

            //Act
            _playlistService.AddComment(playlist, 0, comment);

            //Assert
            Assert.That(playlist.MediaFileItems[0].Comment, Is.EqualTo(comment));
        }
        [Test]
        public void MediaFileCommentIsDeleted()
        {
            //Arrange
            string playlistName = "new playlist";
            string mediaFile = "C:\\Users\\Luke Mansfield\\Downloads\\sample.mp3";
            string comment = "cool song";

            var playlist = _playlistService.CreatePlaylist(playlistName);
            _playlistService.AddMediaFileToPlaylist(playlist.PlayListID, mediaFile);
            _playlistService.AddComment(playlist, 0, comment);

            //Act
            _playlistService.DeleteComment(playlist, 0);
            //Assert
            Assert.That(playlist.MediaFileItems[0].Comment, Is.EqualTo(""));
        }

    }
}
