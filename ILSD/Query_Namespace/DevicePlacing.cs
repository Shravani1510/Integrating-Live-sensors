using System;
using System.Collections.Generic;

namespace Device_Query_Connection.Query_Namespace
{
    /// <summary>
    ///representing devices(Sensor)
    /// </summary>
    public class DevicePlacing
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public DevicePlacing() { }

        private int room_number;

        /// <summary>
        ///constructor
        /// </summary>
        public DevicePlacing(int num)
        {
            this.room_number = num;
        }

        /// <summary>
        ///returns the string device name  w.r.t their room number
        /// </summary>
        public string Room_WA(int room_number)
        {
            string device = "";
            switch (room_number)
            {
                case 201:
                    device = "HM_201_TH_WA";
                    break;
                case 204:
                    device = "HM_204_TH_WA";
                    break;
                case 205:
                    device = "HM_205_TH_WA";
                    break;
                case 206:
                    device = "HM_206_TH_WA ";
                    break;
                case 207:
                    device = "HM_207_TH_WA ";
                    break;
                case 208:
                    device = "HM_208_TH_WA ";
                    break;
                case 210:
                    device = "HM_210_TH_WA";
                    break;
                case 211:
                    device = "HM_211_TH_WA";
                    break;
               
                default:
                    Console.WriteLine("Room_WA number is invalid!");
                    break;
            }
            return device;
        }

        /// <summary>
        ///returns the string device name  w.r.t  device number
        /// </summary>
        public string Powerplug(int number)
        {
            string device = " ";
            switch (number)
            {
                case 1:
                    device = "HM_PP_1";
                    break;
                case 2:
                    device = "HM_PP_2";
                    break;
                case 3:
                    device = "HM_PP_3";
                    break;
                default:
                    Console.WriteLine("Entered number is invalid to choose PowerPlug device");
                    break;
            }
            return device;
        }

        /// </summary>
        ///returns the string device name  w.r.t their room number
        /// <summary>
        public string Room_TH(int room_number)
        {
            string device = "";
            switch (room_number)
            {
                case 201:
                    device = "HM_201_TH_HZ_NORTH";
                    break;
                case 204:
                    device = "HM_204_TH_HZ_EAST";
                   
                    break;
                case 205:
                    device = "HM_205_TH_HZ_EAST";
                    break;
                case 206:
                    device = "HM_206_TH_HZ_WEST";  
                    break;
                case 207:
                    device = "HM_207_TH_HZ_WEST";
                    break;
                case 208:
                    device = "HM_208_TH_HZ_SOUTHWEST";
                    break;
                case 210:
                    device = "HM_210_TH_HZ_SOUTHWEST";
                    break;
                case 211:
                    device = "HM_211_TH_HZ_WEST";
                    break;
                default:
                    Console.WriteLine("Entered value is invalid to choose Temperature humidity device!");
                    break;
            }
            return device;
        }

        /// <summary>
        /// return the room number from the list 
        /// </summary>
        public int RandomNumber()
        {
            Random rand = new Random();

            var list = new List<int> { 201, 204, 205, 206, 207,208, 210, 211 };
            int x = rand.Next(list.Count);
            
            return list[x];

        }

        /// <summary>
        ///  return the Powerplug device number from the list
        /// </summary>
        public int RandomNumber2()
        {
            Random rand = new Random();
            var list = new List<int> { 1, 2, 3 };
            int x = rand.Next(list.Count);
            return list[x];
        }
    }
}
