using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace Haley
{

    public partial class Haley_Sight : Form
    {
        Choices Commands = new Choices();
        static SpeechSynthesizer SpeechSynth = new SpeechSynthesizer();
        static SpeechRecognitionEngine r = new SpeechRecognitionEngine();
        public static Haley_Responce HaleyRes = new Haley_Responce();
        public static PictureBox HaleyLooks = new PictureBox();
        
        Stopwatch Tt = new Stopwatch();
        static Stopwatch Tout = new Stopwatch();

        //commands 
        static List<Lister> GlobalCommands = new List<Lister>();
        public static Dictionary<int, Action> Methods = new Dictionary<int, Action>();

        /*static List<string> ComGreatings = new List<string>();
        static List<string> ComTime = new List<string>();
        static List<string> ComLeavings = new List<string>();
        static List<string> ComDate = new List<string>();
        static List<string> ComWake = new List<string>();
        static List<string> ComSMusic = new List<string>();
        static List<string> ComPMusic = new List<string>();
        static List<string> ComEMusic = new List<string>();
        static List<string> ComNMusic = new List<string>();
        static List<string> ComLMusic = new List<string>();*/

        public static Condition HaleyStatus = new Condition();
        private static Boolean VoicePresent = false;

        public Haley_Sight()
        {
            InitializeComponent();
            //var Commands = new List<Command>();
            //GlobalList = Commands;
            HaleyStatus = Condition.Sleep;
            string resource_command = Properties.Resources.HaleyCommands;
            string[] temp = resource_command.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            HaleyRes.Update();
            Haley_Media.Start();
            Methods.Add(1, () => HaleyRes.IntroResponce());
            Methods.Add(2, () => HaleyRes.WakeResponce());
            Methods.Add(3, () => HaleyRes.GreetingResponce());
            Methods.Add(4, () => HaleyRes.LeavingResponce());
            Methods.Add(5, () => HaleyRes.TimeResponce());
            Methods.Add(6, () => HaleyRes.DateResponce());
            Methods.Add(7, () => HaleyRes.MusicQResponce());
            Methods.Add(8, () => HaleyRes.CancelResponce());
            Methods.Add(9, () => Haley_Media.PlayMusic());
            Methods.Add(10, () => Haley_Media.StopMusic());
            Methods.Add(11, () => Haley_Media.NextTrack());
            Methods.Add(12, () => Haley_Media.PrevTrack());
            /*string line;
            string Checkline;
            string Checkchar;
            string Trueline;
            string LastCheck;*/


            int IDG = 0;
            foreach (var item in temp)
            {
                Console.WriteLine(item);
                string s = item.Trim(new Char[] { '[', ']' });
                int Index = s.IndexOf(',');
                string IDirection = s.Substring(0, Index);
                int IUnix = int.Parse(s.Substring(s.LastIndexOf(',') + 1));
                Console.WriteLine(IUnix + "/" + IDirection);
                GlobalCommands.Add(new Lister { ID = IDG, Direction = IDirection, Unix = IUnix });
                IDG++;
                Commands.Add(IDirection);
                /*Checkline = item.ToString();
                Checkchar = item.Substring(0, 1);
                LastCheck = item.Substring(item.Length - 1, 1);
                if (Checkchar == "<")
                {
                    if (Checkline == "<Greatings>")
                        ComGroup = 1;
                    else if (Checkline == "<Time Request>")
                        ComGroup = 2;
                    else if (Checkline == "<Leaving>")
                        ComGroup = 3;
                    else if (Checkline == "<Date>")
                        ComGroup = 4;
                    else if (Checkline == "<Wake>")
                        ComGroup = 5;
                    else if (Checkline == "<SMusic>")
                        ComGroup = 6;
                    else if (Checkline == "<PMusic>")
                        ComGroup = 7;
                    else if (Checkline == "<EMusic>")
                        ComGroup = 8;
                    else if (Checkline == "<NMusic>")
                        ComGroup = 9;
                    else if (Checkline == "<LMusic>")
                        ComGroup = 10;
                }
                else if (Checkchar != "<")
                {
                    foreach (var w in Checkline.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        line = w;
                        LastCheck = line.Substring(line.Length - 1, 1);
                        if (Checkchar == "[" && LastCheck != "]")
                        {
                            foreach (var q in line.Split(new string[] { "[" }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                Trueline = q.ToString();
                                Checkchar = Trueline.Substring(0, 1);
                                LastCheck = Trueline.Substring(Trueline.Length - 1, 1);
                                if (LastCheck == " ")
                                    Trueline = Trueline.Substring(0, Trueline.Length - 1);
                                if (Checkchar == " ")
                                    Trueline = Trueline.Substring(1, Trueline.Length - 1);

                                if (ComGroup == 1)
                                    ComGreatings.Add(Trueline);
                                else if (ComGroup == 2)
                                    ComTime.Add(Trueline);
                                else if (ComGroup == 3)
                                    ComLeavings.Add(Trueline);
                                else if (ComGroup == 4)
                                    ComDate.Add(Trueline);
                                else if (ComGroup == 5)
                                    ComWake.Add(Trueline);
                                else if (ComGroup == 6)
                                    ComSMusic.Add(Trueline);
                                else if (ComGroup == 7)
                                    ComPMusic.Add(Trueline);
                                else if (ComGroup == 8)
                                    ComEMusic.Add(Trueline);
                                else if (ComGroup == 9)
                                    ComNMusic.Add(Trueline);
                                else if (ComGroup == 10)
                                    ComLMusic.Add(Trueline);
                            }
                        }
                        else if (Checkchar != "[" && LastCheck == "]")
                        {
                            foreach (var q in line.Split(new string[] { "]" }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                Trueline = q.ToString();
                                Checkchar = Trueline.Substring(0, 1);
                                LastCheck = Trueline.Substring(Trueline.Length - 1, 1);
                                if (LastCheck == " ")
                                    Trueline = Trueline.Substring(0, Trueline.Length - 1);
                                if (Checkchar == " ")
                                    Trueline = Trueline.Substring(1, Trueline.Length - 1);

                                if (ComGroup == 1)
                                    ComGreatings.Add(Trueline);
                                else if (ComGroup == 2)
                                    ComTime.Add(Trueline);
                                else if (ComGroup == 3)
                                    ComLeavings.Add(Trueline);
                                else if (ComGroup == 4)
                                    ComDate.Add(Trueline);
                                else if (ComGroup == 5)
                                    ComWake.Add(Trueline);
                                else if (ComGroup == 6)
                                    ComSMusic.Add(Trueline);
                                else if (ComGroup == 7)
                                    ComPMusic.Add(Trueline);
                                else if (ComGroup == 8)
                                    ComEMusic.Add(Trueline);
                                else if (ComGroup == 9)
                                    ComNMusic.Add(Trueline);
                                else if (ComGroup == 10)
                                    ComLMusic.Add(Trueline);
                            }
                        }
                        else if (Checkchar != "]" && LastCheck != "]")
                        {
                            Trueline = line;
                            Checkchar = Trueline.Substring(0, 1);
                            LastCheck = Trueline.Substring(Trueline.Length - 1, 1);
                            if (LastCheck == " ")
                                Trueline = Trueline.Substring(0, Trueline.Length - 1);
                            if (Checkchar == " ")
                                Trueline = Trueline.Substring(1, Trueline.Length - 1);

                            if (ComGroup == 1)
                                ComGreatings.Add(Trueline);
                            else if (ComGroup == 2)
                                ComTime.Add(Trueline);
                            else if (ComGroup == 3)
                                ComLeavings.Add(Trueline);
                            else if (ComGroup == 4)
                                ComDate.Add(Trueline);
                            else if (ComGroup == 5)
                                ComWake.Add(Trueline);
                            else if (ComGroup == 6)
                                ComSMusic.Add(Trueline);
                            else if (ComGroup == 7)
                                ComPMusic.Add(Trueline);
                            else if (ComGroup == 8)
                                ComEMusic.Add(Trueline);
                            else if (ComGroup == 9)
                                ComNMusic.Add(Trueline);
                            else if (ComGroup == 10)
                                ComLMusic.Add(Trueline);
                        }
                        else if (Checkchar == "[" && LastCheck == "]")
                        {
                            foreach (var q in line.Split(new string[] { "]" }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                foreach (var e in q.Split(new string[] { "[" }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    Trueline = e.ToString();
                                    Checkchar = Trueline.Substring(0, 1);
                                    LastCheck = Trueline.Substring(Trueline.Length - 1, 1);
                                    if (LastCheck == " ")
                                        Trueline = Trueline.Substring(0, Trueline.Length - 1);
                                    if (Checkchar == " ")
                                        Trueline = Trueline.Substring(1, Trueline.Length - 1);

                                    if (ComGroup == 1)
                                        ComGreatings.Add(Trueline);
                                    else if (ComGroup == 2)
                                        ComTime.Add(Trueline);
                                    else if (ComGroup == 3)
                                        ComLeavings.Add(Trueline);
                                    else if (ComGroup == 4)
                                        ComDate.Add(Trueline);
                                    else if (ComGroup == 5)
                                        ComWake.Add(Trueline);
                                    else if (ComGroup == 6)
                                        ComSMusic.Add(Trueline);
                                    else if (ComGroup == 7)
                                        ComPMusic.Add(Trueline);
                                    else if (ComGroup == 8)
                                        ComEMusic.Add(Trueline);
                                    else if (ComGroup == 9)
                                        ComNMusic.Add(Trueline);
                                    else if (ComGroup == 10)
                                        ComLMusic.Add(Trueline);
                                }
                            }
                        }
                    }
                }*/
            }
            /*
            foreach (var item in ComGreatings)
                Commands.Add(item);
            foreach (var item in ComTime)
                Commands.Add(item);
            foreach (var item in ComLeavings)
                Commands.Add(item);
            foreach (var item in ComDate)
                Commands.Add(item);
            foreach (var item in ComWake)
                Commands.Add(item);
            foreach (var item in ComSMusic)
                Commands.Add(item);
            foreach (var item in ComPMusic)
                Commands.Add(item);
            foreach (var item in ComEMusic)
                Commands.Add(item);
            foreach (var item in ComNMusic)
                Commands.Add(item);
            foreach (var item in ComLMusic)
                Commands.Add(item);
                */
            SpeechSynth.SelectVoice("Microsoft Zira Desktop");
            Grammar gr = new Grammar(new GrammarBuilder(Commands));
            gr.Priority = 2;
            gr.Weight = 0.8f;
            try
            {
                r.RequestRecognizerUpdate();
                r.InitialSilenceTimeout = TimeSpan.FromSeconds(3);
                r.BabbleTimeout = TimeSpan.FromSeconds(2);
                r.EndSilenceTimeout = TimeSpan.FromSeconds(1);
                r.EndSilenceTimeoutAmbiguous = TimeSpan.FromSeconds(1.5);
                r.LoadGrammar(gr);
                r.SpeechRecognized += r_SpeechRecgognized;
                r.SetInputToDefaultAudioDevice();
                r.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return; }
            HaleyRes.IntroResponce();         
        }        

        private void Haley_Sight_Load(object sender, EventArgs e)
        {
            HaleyLooks.Location = new System.Drawing.Point(0, 0);
            HaleyLooks.Size = new System.Drawing.Size(312, 312);
            HaleyLooks.Dock = DockStyle.Fill;
            HaleyLooks.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            HaleyLooks.Image = Haley.Properties.Resources.HaleySleep;
            this.Controls.Add(HaleyLooks);
        }

        public static void Haley_Speech(string W)
        {
            SpeechSynth.Speak(W);
        }

       private static void r_SpeechRecgognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence >= 0.7)
            {
              if (HaleyStatus == Condition.Awake)
                {                    
                    string Rec = e.Result.Text;
                    Console.WriteLine(Rec);
                    foreach (var item in GlobalCommands)
                        if (Rec == item.Direction)
                        {
                            Haley_Looks.Expess("Active");
                            Methods[item.Unix]();
                            VoicePresent = true;
                            Task t = Timeout();
                            break;
                        }
                }
                else if (HaleyStatus == Condition.Sleep)
                {
                    string Rec = e.Result.Text;
                    Console.WriteLine(Rec);
                    foreach (var item in GlobalCommands)
                        if (Rec == item.Direction)
                        {
                            Methods[item.Unix]();
                            StateChange(1);
                            VoicePresent = true;
                            Task t = Timeout();
                            break;
                        }
                }
                else if (HaleyStatus == Condition.Music)
                {
                    string Rec = e.Result.Text;
                    Console.WriteLine(Rec);
                    if (Rec == "any song available" || Rec == "random song" || Rec == "any song")
                    {
                        Haley_Media.RndSelectMusic();
                        VoicePresent = true;
                        Task t = Timeout();
                    }
                    else if (Rec == "cancel selection" || Rec == "hayle cancel")
                    {
                        Haley_Looks.Expess("Awake");
                        HaleyRes.CancelResponce();
                        VoicePresent = true;
                        Task t = Timeout();
                    }
                    else foreach (var item in Haley_Media.MusicList)
                    {
                        if (Rec == item)
                        {
                            Haley_Media.SelectMusic(Rec);
                            VoicePresent = true;
                            Task t = Timeout();
                            break;
                        }
                    }                    
                }
            }
        } 

        private static async Task<Boolean> Timeout()
        {
            Task t = Task.Run(() =>
            {
                if (HaleyStatus == Condition.Awake)
                {
                    if (VoicePresent)
                    {
                        Tout.Restart();
                        VoicePresent = false;
                    }

                    while (!VoicePresent && HaleyStatus == Condition.Awake)
                    {
                        if (Tout.ElapsedMilliseconds > 8000)
                        {
                            System.GC.Collect();
                            StateChange(0);
                        }
                    }
                }
                else
                {
                    Tout.Reset();
                    Tout.Stop();
                }
            });
            await t;
            return VoicePresent;
        }

        public static void StateChange(int State)
        {
            if (State == 0)
            {
                HaleyStatus = Condition.Sleep;
                Haley_Looks.Expess("Sleep");
            }
            if (State == 1)
            { 
                HaleyStatus = Condition.Awake;
                Haley_Looks.Expess("Awake");
            }
            if (State == 2)
            {
                HaleyStatus = Condition.Music;
                Haley_Looks.Expess("Active");
            }
        }

        public static void UpdateGrammar(Grammar Gram)
        {
            if (!r.Grammars.Contains(Gram))
            {
                try
                {
                    r.LoadGrammar(Gram); ;
                    r.RequestRecognizerUpdate();
                }
                catch (Exception e) { Console.Write(e); }
            }
        }

        public static void DeleteGrammar(Grammar Gram)
        {
            if (r.Grammars.Contains(Gram))
            {
                try
                {
                    r.UnloadGrammar(Gram);
                    r.RequestRecognizerUpdate();
                } catch(Exception e) { Console.Write(e); }
            }
        }

        public static void LooksUpdate(Image PictureSet)
        {
            HaleyLooks.BackgroundImage = PictureSet;
        }
    }

    public enum Condition
    {
        Awake,
        Sleep,
        Music,
    };

    public class Lister
    {
        public int ID { get; set; }
        public string Direction { get; set; }
        public int Unix { get; set; }
    }
}
