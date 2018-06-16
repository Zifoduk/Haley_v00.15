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
        private Configuration Config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        Choices Commands = new Choices();
        static SpeechSynthesizer SpeechSynth = new SpeechSynthesizer();
        static SpeechRecognitionEngine SpeechRecEng = new SpeechRecognitionEngine();
        public static Haley_Responce HaleyRes = new Haley_Responce();
        public static PictureBox HaleyLooks = new PictureBox();
        
        Stopwatch Tt = new Stopwatch();
        static Stopwatch Tout = new Stopwatch();

        //commands 
        static List<Lister> GlobalCommands = new List<Lister>();
        public static Dictionary<int, Action> Methods = new Dictionary<int, Action>();

        public static Condition HaleyStatus = new Condition();
        private static Boolean VoicePresent = false;

        public Haley_Sight()
        {
            InitializeComponent();
            HaleyStatus = Condition.Sleep;
            string resource_command = Properties.Resources.HaleyCommands;
            string[] temp = resource_command.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

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
            }

            Initalize();

            HaleyRes.Update();
            Haley_Media.Initialize();
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




            HaleyRes.IntroResponce();    
        }       
        
        private void Initalize()
        {
            SpeechSynth.SelectVoice(Config.AppSettings.Settings["VoiceSelected"].Value.ToString());
            Grammar gr = new Grammar(new GrammarBuilder(Commands));
            gr.Priority = 2;
            gr.Weight = 0.8f;

            Console.WriteLine(SpeechSynth.Voice.Name);

            try
            {
                SpeechRecEng.RequestRecognizerUpdate();
                SpeechRecEng.InitialSilenceTimeout = TimeSpan.FromSeconds(3);
                SpeechRecEng.BabbleTimeout = TimeSpan.FromSeconds(2);
                SpeechRecEng.EndSilenceTimeout = TimeSpan.FromSeconds(1);
                SpeechRecEng.EndSilenceTimeoutAmbiguous = TimeSpan.FromSeconds(1.5);
                SpeechRecEng.LoadGrammar(gr);
                SpeechRecEng.SpeechRecognized += r_SpeechRecgognized;
                SpeechRecEng.SetInputToDefaultAudioDevice();
                SpeechRecEng.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return; }
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
            Condition temp = new Condition();
            temp = HaleyStatus;
            SpeechSynth.Speak(W);
            while (SpeechSynth.State == SynthesizerState.Speaking)
            {
                HaleyStatus = Condition.Active;
            }
            try
            {
                HaleyStatus = temp;
            }
            catch (Exception e)
            {
                Console.WriteLine("exception caught " + e);
            }
        }

       private static void r_SpeechRecgognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence >= 0.82 && !VoicePresent && HaleyStatus != Condition.Active)
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
                            if (item.Unix == 2)
                            {
                                Methods[item.Unix]();
                                StateChange(1);
                                VoicePresent = true;
                                Task t = Timeout();
                                break;
                            }
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
            if (!SpeechRecEng.Grammars.Contains(Gram))
            {
                try
                {
                    SpeechRecEng.LoadGrammar(Gram); ;
                    SpeechRecEng.RequestRecognizerUpdate();
                }
                catch (Exception e) { Console.Write(e); }
            }
            List<string> temp = new List<string>();
            //Console.WriteLine(r.Grammars.ToList<>(););
        }

        public static void DeleteGrammar(Grammar Gram)
        {
            if (SpeechRecEng.Grammars.Contains(Gram))
            {
                try
                {
                    SpeechRecEng.UnloadGrammar(Gram);
                    SpeechRecEng.RequestRecognizerUpdate();
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
        Active,
    };

    public class Lister
    {
        public int ID { get; set; }
        public string Direction { get; set; }
        public int Unix { get; set; }
    }
    
   /* public class Dis_uni
    {
        public int DX_1S { get; set;}s
        public float RND_ISX { get; return DX_1S; set as Parce.int64(1, int64.index[i]; i++; i.getindex();]);}
        public Lister.ID.Validate Valdid VD () => ++i;(i).int.parce(); 
    }*/
}
