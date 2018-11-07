using System;
using System.Collections.Generic; //for List<T> 
using System.Management; //need add reference like:project==>add==>reference==>choose system.Management to add



namespace GetWin32Dvc
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0) 
            {
                Console.WriteLine("Usage: must define the pnp device keyword eg.Getwin32Dvc HID");
                Console.WriteLine("      if want to get all of the pnp device, Getwin32Dvc All ");
                Console.WriteLine("\n[Ver 1.0] Copyright (c) 2017 USI Software Inc All rights reserverd ");
                return 2;
            }
           
            switch(args[0].ToLower()) 
            {
                case "all":
                    var Devices = GetDevicesAll();
                     foreach (var Device in Devices)
                    {
              
                         Console.WriteLine("Device ID: {0} \nDescription: {1}\n",
                        Device.DeviceID,  Device.Description);
                         }
                     return 0;
                     break;
                     
                    
                default:
                   var DevicesAll = GetDevices(args[0]);
                   foreach (var Device in DevicesAll)
                   {

                       Console.WriteLine("Device ID: {0} \nDescription: {1}\n",
                      Device.DeviceID, Device.Description);
                   }
                
                   return 0;
            }
               
            

           
        }

        static List<DeviceInfo> GetDevices(string keyword)
        {
            List<DeviceInfo> devices = new List<DeviceInfo>();

            ManagementObjectCollection collection;
            //using and define searcher
            using (var searcher = new ManagementObjectSearcher("Select * From Win32_PnPEntity where DeviceID Like \"" + keyword + "%\"")) 
                //Get() is the method to get the query result
                collection = searcher.Get();
            
            foreach (var device in collection)
            {
                devices.Add(new DeviceInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("Description")
                ));
            }
            
            collection.Dispose();
            return devices;
        }

        static List<DeviceInfo> GetDevicesAll()
        {
            List<DeviceInfo> devices = new List<DeviceInfo>();

            ManagementObjectCollection collection;
            //using and define searcher
            using (var searcher = new ManagementObjectSearcher("Select * From Win32_PnPEntity"))
                //Get() is the method to get the query result
                collection = searcher.Get();

            foreach (var device in collection)
            {
                devices.Add(new DeviceInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("Description")
                ));
            }

            collection.Dispose();
            return devices;
        }

        class DeviceInfo
        {
            public DeviceInfo(string deviceID,  string description)
            {
                this.DeviceID = deviceID;
                this.Description = description;
            
            }
            public string DeviceID { get; private set; }
            public string Description { get; private set; }
            public string Status { get; private set; }
        }
    }
}
