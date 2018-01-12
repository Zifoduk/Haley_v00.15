using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Diagnostics;
using WMPLib;


namespace Haley
{
    class Haley_Media
    {
        public static Choices MusicCommands = new Choices();
        public static string[] MusicList;
        private static int CurrentSong;
        static Haley_Responce HaleyResp = Haley_Sight.HaleyRes;
        public static Grammar grm;
        public static WindowsMediaPlayer MusicPlayer = new WindowsMediaPlayer();
        static Configuration ConfigManager = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        public static string[] sd = Directory.GetFiles(ConfigManager.AppSettings.Settings["Mlocation"].Value, "*.mp3", SearchOption.AllDirectories).ToArray();
        public static string[] cn;
        
        public static void Start()
        {    
            cn = 
            string MusicLoc = ConfigManager.AppSettings.Settings["Mlocation"].Value;            
            Console.WriteLine(MusicPlayer.URL.ToString());
            MusicList = Directory.GetFiles(MusicLoc, "*.mp3", SearchOption.AllDirectories).Select(Path.GetFileNameWithoutExtension).ToArray();
            foreach (var item in MusicList)
            {
                MusicCommands.Add(item.ToString());
            }
            MusicCommands.Add("any song available", "random song", "any song", "cancel selection", "hayle cancel");
            grm = new Grammar(new GrammarBuilder(MusicCommands));
            grm.Priority = 1;
            grm.Weight = 0.5f;
        }

        public static void MusicResponce()
        {
            Haley_Sight.UpdateGrammar(grm);
        }

        public static void MusicGramRemove()
        {
            Haley_Sight.DeleteGrammar(grm);
        }

        public static void RndSelectMusic()
        {
            Random RanPull = new Random();
            int choice = 0;
            choice = RanPull.Next(0, sd.Count());

            CurrentSong = choice;
            string Sender = sd[choice].ToString();
            MusicPlayer.URL = Sender;
            ConfigManager.AppSettings.Settings["MCurrent"].Value = Sender;
            ConfigManager.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
            PlayMusic();
            Haley_Sight.Haley_Speech("Ok");
            Haley_Sight.HaleyStatus = Condition.Awake;
        }

        public static void SelectMusic(string song)
        {
            string truetemp = "";

            foreach(var item in sd)
            {
                string tempfile = Path.GetFileNameWithoutExtension(item);
                if (tempfile == song)
                {
                    truetemp = item;
                    CurrentSong = Array.IndexOf(sd, item);
                    Console.WriteLine(Array.IndexOf(sd, item));
                    break;
                }
            }
            
            Haley_Sight.HaleyStatus = Condition.Awake;
            string Sender = truetemp;
            Console.WriteLine(CurrentSong);
            MusicPlayer.URL = Sender;
            ConfigManager.AppSettings.Settings["MCurrent"].Value = Sender;
            Console.WriteLine(ConfigManager.AppSettings.Settings["MCurrent"].Value);
            ConfigManager.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection(ConfigManager.AppSettings.SectionInformation.Name);
            PlayMusic();
            Haley_Sight.Haley_Speech("Ok");
        }

        public static void PlayMusic()
        {
            try
            {
                if (MusicPlayer.URL != null)
                {
                    if (MusicPlayer.playState == WMPPlayState.wmppsStopped || MusicPlayer.playState == WMPPlayState.wmppsPaused)                    
                        MusicPlayer.controls.play();                    
                }
                else Haley_Sight.Haley_Speech("No track loaded");
            }
            catch (Exception e)
            {
                Haley_Sight.Haley_Speech("No track loaded");
                return;
            }
        }

        public static void StopMusic()
        {
            try
            {
                if(MusicPlayer.URL != null)
                { 
                    if (MusicPlayer.playState == WMPPlayState.wmppsPlaying)
                        MusicPlayer.controls.pause();
                }
                else Haley_Sight.Haley_Speech("No track loaded");
            }
            catch (Exception e)
            {
                Haley_Sight.Haley_Speech("No track loaded");
                return;
            }
        }

        public static void NextTrack()
        {
            if (MusicPlayer.URL != null)
            {
                if (MusicPlayer.playState == WMPPlayState.wmppsPlaying)
                {
                    Console.WriteLine(CurrentSong);
                    CurrentSong++;
                    string Sender = sd[CurrentSong];

                    Console.WriteLine(CurrentSong);
                    Console.WriteLine(Sender);
                    MusicPlayer.URL = Sender;
                    MusicPlayer.controls.play();
                }
                else if (MusicPlayer.playState == WMPPlayState.wmppsStopped || MusicPlayer.playState == WMPPlayState.wmppsPaused)
                {
                    try
                    {
                        Console.WriteLine(CurrentSong);
                        CurrentSong++;
                        string Sender = sd[CurrentSong];

                        Console.WriteLine(CurrentSong);
                        Console.WriteLine(Sender);
                        MusicPlayer.URL = Sender;
                        MusicPlayer.controls.play();
                    }
                    catch { return; }
                }
            }
            else return;
        }

        public static void PrevTrack()
        {
            if (MusicPlayer.URL != null)
            {
                if (MusicPlayer.playState == WMPPlayState.wmppsPlaying)
                {
                    Console.WriteLine(CurrentSong);

                    CurrentSong --;
                    Console.WriteLine(CurrentSong);
                    string Sender = sd[CurrentSong];
                    Console.WriteLine(Sender);
                    MusicPlayer.URL = Sender;
                    MusicPlayer.controls.play();
                }
                else if (MusicPlayer.playState == WMPPlayState.wmppsStopped || MusicPlayer.playState == WMPPlayState.wmppsPaused)
                {
                    try
                    {
                        CurrentSong--;
                        Console.WriteLine(CurrentSong);
                        string Sender = sd[CurrentSong];

                        Console.WriteLine(CurrentSong);
                        Console.WriteLine(Sender);
                        MusicPlayer.URL = Sender;
                        MusicPlayer.controls.play();
                    }
                    catch { return; }
                }
            }
            else return;
        }

        private void MusicPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if(e.newState == 1)
            {
                NextTrack();
            }
        }
    }
}
