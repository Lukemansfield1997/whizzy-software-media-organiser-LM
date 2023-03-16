using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whizzy_software_media_organiser_LM.Interfaces;

namespace whizzy_software_media_organiser_LM.Services
{
    public class NAudioPlayerService: IMediaPlayer
    {
        private AudioFileReader _audioFileReader;
        private WaveOut _waveOut;

        public void LoadMediaFile(string filePath)
        {
            _waveOut = new WaveOut();
            _audioFileReader = new AudioFileReader(filePath);

            // waveout.Init will configure the Audioplayer to play the filePath within the AudioFileReader object
            _waveOut.Init(_audioFileReader);
        }

        public void Pause()
        {
            _waveOut.Pause();
        }

        public void Play()
        {

            _waveOut.Play();
        }

        public void Resume()
        {
            _waveOut.Resume();
        }

        public void Stop()
        {
            if (_waveOut != null)
            {
                _waveOut.Stop();
                _waveOut.Dispose();
            }
        }
    }
}
