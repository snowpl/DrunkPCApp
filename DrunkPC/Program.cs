using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Media;
//
// Application Name: Drunk PC
//


namespace DrunkPC
{
    class Program
    {
        public static Random _random = new Random();
        public static int _startUpDelaySeconds = 10;
        public static int _totalDurationSeconds = 120;
        static void Main(string[] args)
        {

            if(args.Length >= 2)
            {
                _startUpDelaySeconds = Convert.ToInt32(args[0]);
                _totalDurationSeconds = Convert.ToInt32(args[1]);
            }

            Console.WriteLine("Drunk PC App by Kacpi copyrights to Barnacules");

            // create all threads
            Thread drunkMouseThread = new Thread(new ThreadStart(DrunkMouseThread));
            Thread drunkKeyboardThread = new Thread(new ThreadStart(DrunkKeyboardThread));
            Thread drunkSoundThread = new Thread(new ThreadStart(DrunkSoundThread));
            Thread drunkPopUpThread = new Thread(new ThreadStart(DrunkPopUpThread));

            DateTime future = DateTime.Now.AddSeconds(_startUpDelaySeconds);
            while (future > DateTime.Now)
            {
                Thread.Sleep(1000);
            }

            //start all threads
            drunkMouseThread.Start();
        //    drunkKeyboardThread.Start();
         //   drunkSoundThread.Start();
            drunkPopUpThread.Start();

            future = DateTime.Now.AddSeconds(_totalDurationSeconds);
            while (future > DateTime.Now)
            {
                Thread.Sleep(1000);
            }

            // kill all threads & exit app
            drunkMouseThread.Abort();
           // drunkKeyboardThread.Abort();
           // drunkSoundThread.Abort();
            drunkPopUpThread.Abort();

        }
        //#region Thread Functions
        // this thread move randomly mouse
        public static void DrunkMouseThread()
        {

            Console.WriteLine("DrunkMouseThread started");
         
                int moveX=0, moveY=0;
                while (true)
                {
                    //generate to random amount
                    moveX = _random.Next(20) - 10;
                    moveY = _random.Next(20) - 10;

                    // change mouse position
                    Cursor.Position = new System.Drawing.Point(Cursor.Position.X + moveX, Cursor.Position.Y + moveY);
                    Thread.Sleep(50);
                
            }

        }
        // this thread will generate random keboard output
        public static void DrunkKeyboardThread()
        {
            Console.WriteLine("DrunkKeyboardThread started");
            while (true)
            {
                if (_random.Next(100) > 70)
                {
                    //generate random capital letter
                    char key = (char)(_random.Next(25) + 65);

                    //50-50 make it lowercase
                    if (_random.Next(2) == 0)
                    {
                        key = Char.ToLower(key);
                    }

                    SendKeys.SendWait(key.ToString());

                    Thread.Sleep(_random.Next(5000));
                }
            }

        }
        //this will play random sounds, 2 piss you off
        public static void DrunkSoundThread()
        {
            Console.WriteLine("DrunkSoundThread started");
            while (true)
            {
                if (_random.Next(100) > 50)
                {
                    switch(_random.Next(5))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;
                        case 1:
                            SystemSounds.Beep.Play();
                            break;
                        case 2:
                            SystemSounds.Exclamation.Play();
                            break;
                        case 3:
                            SystemSounds.Hand.Play();
                            break;
                        case 4:
                            SystemSounds.Question.Play();
                            break;
                    }
                    Thread.Sleep(10000);
                }

            }

        }
        // its a prank bro!
        public static void DrunkPopUpThread()
        {
            Console.WriteLine("DrunkPopUpThread started");
            while (true)
            {
                if(_random.Next(100)>90)
                    switch(_random.Next(2))
                    {
                        case 0:
                            MessageBox.Show(
 "Internet explorer has stopped working",
 "Internet Explorer",
 MessageBoxButtons.OK,
 MessageBoxIcon.Error);
                            break;
                        case 1:
                            MessageBox.Show(
 "Your system is running low on resources",
 "Microsoft Windows",
 MessageBoxButtons.OK,
 MessageBoxIcon.Warning);
                            break;
                    }

                Thread.Sleep(10000);
            }

        }
    }
}
