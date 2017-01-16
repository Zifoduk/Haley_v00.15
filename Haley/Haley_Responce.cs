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

namespace Haley
{
    public class Haley_Responce
    {
        public Random RanPull;
        static string ResList;


        static List<Lister> GlobalResponce = new List<Lister>();

       /* List<string> ResIntro = new List<string>();
        List<string> ResGreatings = new List<string>();
        List<string> ResTime = new List<string>();
        List<string> ResLeavings = new List<string>();
        List<string> ResDate = new List<string>();
        List<string> ResWake = new List<string>();
        List<string> ResMusic = new List<string>();
        List<string> ResCancel = new List<string>(); */

        public void Update()
        {
            ResList = Haley.Properties.Resources.HaleyResponce;
            string[] temp = ResList.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

           // string line;
           // string Checkline;
           // string Checkchar;
           // string Trueline;
           // string LastCheck;

            int IDG = 0;
            foreach (var item in temp)
            {
                Console.WriteLine(item);
                string s = item.Trim('[', ']');
                Console.WriteLine(s);
                int Index = s.IndexOf(',');
                string IDirection = s.Substring(0, Index);
                Console.WriteLine(IDirection);
                int IUnix = int.Parse(s.Substring(s.LastIndexOf(',') + 1));
                Console.WriteLine(IUnix);
                GlobalResponce.Add(new Lister { ID = IDG, Direction = IDirection, Unix = IUnix });
                /*Checkline = item.ToString();
                Checkchar = item.Substring(0, 1);
                LastCheck = item.Substring(item.Length - 1, 1);
                if (Checkchar == "<")
                {
                    if (Checkline == "<Intro>")
                        ResGroup = 0;
                    else if (Checkline == "<Greatings>")
                        ResGroup = 1;
                    else if (Checkline == "<Time Request>")
                        ResGroup = 2;
                    else if (Checkline == "<Leaving>")
                        ResGroup = 3;
                    else if (Checkline == "<Date>")
                        ResGroup = 4;
                    else if (Checkline == "<Wake>")
                        ResGroup = 5;
                    else if (Checkline == "<Music>")
                        ResGroup = 6;
                    else if (Checkline == "<Cancel>")
                        ResGroup = 7;

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

                                if (ResGroup == 0)
                                    ResIntro.Add(Trueline);
                                else if (ResGroup == 1)
                                    ResGreatings.Add(Trueline);
                                else if (ResGroup == 2)
                                    ResTime.Add(Trueline);
                                else if (ResGroup == 3)
                                    ResLeavings.Add(Trueline);
                                else if (ResGroup == 4)
                                    ResDate.Add(Trueline);
                                else if (ResGroup == 5)
                                    ResWake.Add(Trueline);
                                else if (ResGroup == 6)
                                    ResMusic.Add(Trueline);
                                else if (ResGroup == 7)
                                    ResCancel.Add(Trueline);
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

                                if (ResGroup == 0)
                                    ResIntro.Add(Trueline);
                                else if (ResGroup == 1)
                                    ResGreatings.Add(Trueline);
                                else if (ResGroup == 2)
                                    ResTime.Add(Trueline);
                                else if (ResGroup == 3)
                                    ResLeavings.Add(Trueline);
                                else if (ResGroup == 4)
                                    ResDate.Add(Trueline);
                                else if (ResGroup == 5)
                                    ResWake.Add(Trueline);
                                else if (ResGroup == 6)
                                    ResMusic.Add(Trueline);
                                else if (ResGroup == 7)
                                    ResCancel.Add(Trueline);

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

                            if (ResGroup == 0)
                                ResIntro.Add(Trueline);
                            else if (ResGroup == 1)
                                ResGreatings.Add(Trueline);
                            else if (ResGroup == 2)
                                ResTime.Add(Trueline);
                            else if (ResGroup == 3)
                                ResLeavings.Add(Trueline);
                            else if (ResGroup == 4)
                                ResDate.Add(Trueline);
                            else if (ResGroup == 5)
                                ResWake.Add(Trueline);
                            else if (ResGroup == 6)
                                ResMusic.Add(Trueline);
                            else if (ResGroup == 7)
                                ResCancel.Add(Trueline);
                        }
                    }
                }*/
            }
        }
        
        public string ResponcePicker(int UnixID)
        {
            List<Lister> temp = new List<Lister>();
            foreach(var L in GlobalResponce)
            {
                if (L.Unix == UnixID)
                    temp.Add(L);
            }
            Random Rand = new Random();
            int choice = 0;
            choice = Rand.Next(0, temp.Count);

            String Answer;
            Answer = temp[choice].Direction.ToString();

            return Answer;
        }

        public void IntroResponce()
        {
            int MUnix = 1;
            string Sentence;
            Sentence = ResponcePicker(MUnix);
            Haley_Sight.Haley_Speech(Sentence);
        }

        public void WakeResponce()
        {
            int MUnix = 2;
            string Sentence;
            Sentence = ResponcePicker(MUnix);
            Haley_Sight.Haley_Speech(Sentence);
        }

        public void GreetingResponce()
        {
            int MUnix = 3;
            string Sentence;
            Sentence = ResponcePicker(MUnix);
            Haley_Sight.Haley_Speech(Sentence);
        }

        public void LeavingResponce()
        {
            int MUnix = 4;
            string Sentence;
            Haley_Sight.StateChange(0);
            Sentence = ResponcePicker(MUnix);
            Haley_Sight.Haley_Speech(Sentence);
        }

        public void TimeResponce()
        {
            int MUnix = 5;
            string Sentence;
            Sentence = ResponcePicker(MUnix);
            Haley_Sight.Haley_Speech(Sentence + " " + DateTime.Now.ToString("H mm tt"));
        }

        public void DateResponce()
        {
            int MUnix = 6;
            string Sentence;
            Sentence = ResponcePicker(MUnix);
            Haley_Sight.Haley_Speech(Sentence + " " + DateTime.Now.ToString("dddd MMMM yyyy"));
        }

        public void MusicQResponce()
        {
            int MUnix = 7;
            string Sentence;
            Sentence = ResponcePicker(MUnix);
            Haley_Sight.Haley_Speech(Sentence);
            Haley_Media.MusicResponce();
        }

        public void CancelResponce()
        {
            int MUnix = 8;
            string Sentence;
            Sentence = ResponcePicker(MUnix);
            Haley_Sight.Haley_Speech(Sentence);
            Haley_Sight.StateChange(1);
        }
    }
}
