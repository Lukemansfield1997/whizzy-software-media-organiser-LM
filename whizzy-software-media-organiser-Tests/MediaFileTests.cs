using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whizzy_software_media_organiser_LM.Services;

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

    }
}
