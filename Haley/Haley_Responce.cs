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

        public void Update()
        {
            ResList = Haley.Properties.Resources.HaleyResponce;
            string[] temp = ResList.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

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
            Console.WriteLine(temp.Count.ToString());
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
            Haley_Media.MusicResponce();
            Haley_Sight.HaleyStatus = Condition.Music; 
            Haley_Sight.Haley_Speech(Sentence);
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
