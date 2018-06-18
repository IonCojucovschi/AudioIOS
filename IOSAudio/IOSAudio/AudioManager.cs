using System;
using AVFoundation;
using Foundation;

namespace IOSAudio
{
    public class AudioManager
    {
        #region Private Variables
        private AVAudioPlayer backgroundMusic;
        private AVAudioPlayer soundEffects;
        private string backgroundSong = "";


        #endregion

        #region Computed properties
        public bool MusicOn { get; set; } = true;

        public float MusicVolume { get; set; } = 0.5f;
        #endregion


        #region Public Methosds
        public void ActivateAudioSession()
        {
            //initialize audio
            var session = AVAudioSession.SharedInstance();
            session.SetCategory(AVAudioSessionCategory.Ambient);
            session.SetActive(true);

        }

        public void DeactivateAudioSession()
        {
            var session = AVAudioSession.SharedInstance();
            session.SetActive(false);
        }

        public void ReactivateAudioSession()
        {
            var session = AVAudioSession.SharedInstance();
            session.SetActive(true);
        }


        public void PlaySound(string FileName)
        {
            NSUrl songURl;
            AVAudioPlayer audio=new AVAudioPlayer;
            //music enabled
            if (!MusicOn) return;

            //Any existing sound effects
            if(audio!=null)
            {
                audio.Stop();
                audio.Dispose();
            }

            //initialze background music
            songURl = new NSUrl("Sounds/"+FileName);
            audio = new AVAudioPlayer(songURl, "mp3");
            audio.Volume = MusicVolume;
            audio.FinishedPlaying+=delegate {

                audio = null;
            };
            audio.NumberOfLoops = 0;
            audio.Play();


        }











        #endregion




        #region constructor

        public AudioManager()
        {
            ActivateAudioSession();
        }
#endregion





    }
}
