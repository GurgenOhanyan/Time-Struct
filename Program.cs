using System;
using System.Collections.Generic;
using System.Linq;
namespace TimeStruct
{
    struct Time
    {
        public static int day { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public readonly int noon
        { 
          get => 720;
        }                 
                         
        public Time(string time)
        {
            string h = "";
            if (time[2] != ':')
            {

                throw new Exception("incorrectly entered value");
            }
            for (int i = 0; i < 2; i++)
            {
                h += time[i]; ;
            }
            int possibleErrorHour = Convert.ToInt32(h);
            if (possibleErrorHour > 23)
            {
                throw new Exception("incorrectly entered value");
            }
            this.hour = Convert.ToInt32(h);
            string m = "";
            for (int i = 3; i < 5; i++)
            {
                m += time[i]; ;
            }
            int possibleErrorMinute = Convert.ToInt32(m);
            if (possibleErrorMinute > 59)
            {
                throw new Exception("incorrectly entered value");
            }
            this.minute = Convert.ToInt32(m);
        }
        public static Time operator +(Time t1, Time t2)
        {
            day = 0;
            Time time = new Time();
            time.hour = t1.hour + t2.hour;
            time.minute = t1.minute + t2.minute;
            if (time.minute > 59)
            {
                time.hour++;
                time.minute -= 60;
            }
            if (time.hour > 23)
            {
                day++;
                time.hour -= 24;
            }
            return time;
        }
        public static Time operator -(Time t1, Time t2)
        {
            Time time = new Time();
            if (t1.minute < t2.minute)
            {
                t1.hour--;
                t1.minute += 60;

            }
            if (t1.hour < t2.hour)
            {
                throw new Exception("negative time value");
                
            }
            time.hour = t1.hour - t2.hour;
            time.minute = t1.minute - t2.minute;

            return time;
        }
        public static explicit operator int(Time time)
        {
            return time.hour * 60 + time.minute;
        }
        public static implicit operator Time (int minutes)
        {
            Time time = new Time();
            time.hour = minutes / 60;
            time.minute = minutes % 60;
            return time;
        }


        public override string ToString()
        {
            if (day == 0)
            {
                return $"{this.hour}:{this.minute}";
            }
            return $"{day}:{this.hour}:{this.minute}";
        }
    }
       
    class Program
    {
        static void Main(string[] args)
        { 
             string t1 = Console.ReadLine();
             string t2 = Console.ReadLine();
             //string t3 = Console.ReadLine();
             Time time1 = new Time(t1);
             Time time2 = new Time(t2);
            //Time time3 = new Time(t3);
             Time timeAdd = time1 + time2;
             Console.WriteLine(timeAdd);
            //Time timeSub =timeAdd - time1;
            //Time timeSub = time1 - time2;
            //Console.WriteLine(timeSub);
            //Console.WriteLine(timeSub);
            //int castToInt =(int)time1;
            // Console.WriteLine(castToInt);
            //Time CastToTime = 300;
            // Console.WriteLine(CastToTime);
            // Console.WriteLine(time1.noon);
           
        }
    }
}
