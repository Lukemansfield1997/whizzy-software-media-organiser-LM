namespace whizzy_software_media_organiser_LM.Interfaces
{
    public interface IMediaPlayer
    {
        public void LoadMediaFile(string filePath);
        public void Stop();
        public void Play();
        public void Pause();
        public void Resume();

    }
}