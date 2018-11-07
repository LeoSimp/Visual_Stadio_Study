

using System;
using System.IO.Ports;
using System.Threading;

public class Serial_Loopbk
{
    static int _fail = 0;
    static SerialPort _serialPort;

    public static int Main(string[] args)
    {
        if (args.Length != 1 || !(args[0].ToUpper()).StartsWith("COM"))
        {

            Console.WriteLine("Parameter number not 1; Or Parameter not start with COM");
            //Console.ReadKey();
            return 2;
        }
        bool _COM_match = false;
        Console.WriteLine("COM Port List:");
        foreach (string s in SerialPort.GetPortNames())
        {
            Console.Write("{0} ", s);
            if (s == args[0].ToUpper())
            { _COM_match = true; }
        }
        Console.WriteLine("");
        if (!_COM_match)
        {
            Console.WriteLine("Can not find " + args[0] + ", please check!");
            //Console.ReadKey();
            return 3;
        }
        // Create a new SerialPort object with default settings.
        _serialPort = new SerialPort();

        // Allow the user to set the appropriate properties.
        //_serialPort.PortName = SetPortName(_serialPort.PortName);
        _serialPort.PortName = args[0];
        _serialPort.BaudRate = 115200;
        //_serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
        _serialPort.Parity = System.IO.Ports.Parity.None;
        _serialPort.DataBits = 8;
        //_serialPort.StopBits = (StopBits)Enum. (typeof(StopBits),"One");
        _serialPort.StopBits = System.IO.Ports.StopBits.One;
        //_serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), "None");
        _serialPort.Handshake = System.IO.Ports.Handshake.None;

        // Set the read/write timeouts
        _serialPort.ReadTimeout = 500;
        _serialPort.WriteTimeout = 500;
        _serialPort.Open();

        DTR_DSR_Test();
        Console.WriteLine("");
        DTR_DCD_Test();
        Console.WriteLine("");
        RTS_CTS_Test();
        Console.WriteLine("");
        TXD_RXD_Test();
        Console.WriteLine("");

        if (_fail != 1)
        {
            Console.WriteLine("Loopback Test Total Pass");
        }
        else
        {
            Console.WriteLine("Loopback Test Total Fail");
        }
        //Console.ReadKey();

        _serialPort.Close();
        return (_fail);
    }

    public static void DTR_DSR_Test()
    {
        string Item = "DTR_DSR Pin4_6 High Test";
        Console.WriteLine(Item + " Start... ");
        Console.WriteLine(" DSR begin status:" + _serialPort.DsrHolding.ToString());
        _serialPort.DtrEnable = true;
        Console.WriteLine(" DTR Status set " + _serialPort.DtrEnable.ToString());
        Console.WriteLine(" Detect DSR Status change to " + _serialPort.DsrHolding.ToString());
        if (_serialPort.DsrHolding)
        {
            Console.WriteLine(" " + Item + " Pass");
        }
        else
        {
            Console.WriteLine(" " + Item + " Fail");
            _fail = 1;
        }

        Console.WriteLine("");
        Item = "DTR_DSR Pin4_6 Low Test";
        Console.WriteLine(Item + " Start... ");
        Console.WriteLine(" DSR begin status:" + _serialPort.DsrHolding.ToString());
        _serialPort.DtrEnable = false;
        Console.WriteLine(" DTR Status set " + _serialPort.DtrEnable.ToString());
        Console.WriteLine(" Detect DSR Status change to " + _serialPort.DsrHolding.ToString());
        if (!_serialPort.DsrHolding)
        {
            Console.WriteLine(" " + Item + " Pass");
        }
        else
        {
            Console.WriteLine(" " + Item + " Fail");
            _fail = 1;
        }
    }
    public static void DTR_DCD_Test()
    {

        string Item = "DTR_DCD Pin4_1 High Test";
        Console.WriteLine(Item + " Start... ");
        Console.WriteLine(" DCD begin status:" + _serialPort.CDHolding.ToString());
        _serialPort.DtrEnable = true;
        Console.WriteLine(" DTR Status set " + _serialPort.DtrEnable.ToString());
        Console.WriteLine(" Detect DCD Status change to " + _serialPort.CDHolding.ToString());
        if (_serialPort.CDHolding)
        {
            Console.WriteLine(" " + Item + " Pass");
        }
        else
        {
            Console.WriteLine(" " + Item + " Fail");
            _fail = 1;
        }
        Console.WriteLine("");
        Item = "DTR_DCD Pin4_1 Low Test";
        Console.WriteLine(Item + " Start... ");
        Console.WriteLine(" DCD begin status:" + _serialPort.CDHolding.ToString());
        _serialPort.DtrEnable = false;
        Console.WriteLine(" DTR Status set " + _serialPort.DtrEnable.ToString());
        Console.WriteLine(" Detect DCD Status change to " + _serialPort.CDHolding.ToString());
        if (!_serialPort.CDHolding)
        {
            Console.WriteLine(" " + Item + " Pass");
        }
        else
        {
            Console.WriteLine(" " + Item + " Fail");
            _fail = 1;
        }
    }
    public static void RTS_CTS_Test()
    {
        string Item = "RTS_CTS Pin7_8 High Test";
        Console.WriteLine(Item + " Start... ");
        Console.WriteLine(" CTS begin status:" + _serialPort.CtsHolding.ToString());
        _serialPort.RtsEnable = true;
        Console.WriteLine(" RTS Status set " + _serialPort.RtsEnable.ToString());
        Console.WriteLine(" Detect CTS Status change to " + _serialPort.CtsHolding.ToString());
        if (_serialPort.CtsHolding)
        {
            Console.WriteLine(" RTS_CTS Pin High Test Pass");
        }
        else
        {
            Console.WriteLine(" RTS_CTS Pin High Test Fail");
            _fail = 1;
        }
        Console.WriteLine("");
        Item = "RTS_CTS Pin7_8 Low Test";
        Console.WriteLine(Item + " Start... ");
        Console.WriteLine(" CTS begin status:" + _serialPort.CtsHolding.ToString());
        _serialPort.RtsEnable = false;
        Console.WriteLine(" RTS Status set " + _serialPort.RtsEnable.ToString());
        Console.WriteLine(" Detect CTS Status change to " + _serialPort.CtsHolding.ToString());
        if (!_serialPort.CtsHolding)
        {
            Console.WriteLine(" " + Item + " Pass");
        }
        else
        {
            Console.WriteLine(" " + Item + " Fail");
            _fail = 1;
        }
    }

    public static void TXD_RXD_Test()
    {
        string Item = "TXD_RXD Pin2_3 Data";
        Console.WriteLine(Item + " Start... ");
        Console.Write(" Sending Data: ABCD... ");
        _serialPort.WriteLine(String.Format("ABCD"));
        Console.Write("Recieve Data: ");
        string message = "Null";
        try
        {
            message = _serialPort.ReadLine();
        }
        catch (TimeoutException) { }
        Console.WriteLine(message);
        if (message == "ABCD")
        {
            Console.WriteLine(" " + Item + " Pass");
        }
        else
        {
            Console.WriteLine(" " + Item + " Fail");
            _fail = 1;
        }
    }



}

