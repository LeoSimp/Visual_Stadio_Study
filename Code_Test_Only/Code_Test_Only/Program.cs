using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Video;
using AForge.Video.DirectShow;



namespace Code_Test_Only
{
    class Program
    {
        static void Main(string[] args)
        {
              
           
                //AForge.Video.DirectShow.FilterInfoCollection 设备枚举类
                 FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                 Console.WriteLine("Camera number: " + videoDevices.Count);
                
               
           
                foreach (FilterInfo device in videoDevices)
                {
                    Console.WriteLine ( "Device name: "+ device.Name );
                }
                //默认选择第一项
             
         
        }

    }
}
