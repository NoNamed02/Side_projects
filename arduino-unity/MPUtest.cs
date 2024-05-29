using UnityEngine;
using System.Threading;

public class SerialController_custom : MonoBehaviour
{
    [Tooltip("Port name with which the SerialPort object will be created.")]
    public string portName = "COM3";

    [Tooltip("Baud rate that the serial device is using to transmit data.")]
    public int baudRate = 9600;

    [Tooltip("Reference to an scene object that will receive the events of connection, " +
             "disconnection and the messages from the serial device.")]
    public GameObject messageListener;

    [Tooltip("After an error in the serial communication, or an unsuccessful " +
             "connect, how many milliseconds we should wait.")]
    public int reconnectionDelay = 1000;

    [Tooltip("Maximum number of unread data messages in the queue. " +
             "New messages will be discarded.")]
    public int maxUnreadMessages = 1;

    public const string SERIAL_DEVICE_CONNECTED = "__Connected__";
    public const string SERIAL_DEVICE_DISCONNECTED = "__Disconnected__";

    protected Thread thread;
    protected SerialThreadLines serialThread;

    void OnEnable()
    {
        serialThread = new SerialThreadLines(portName, baudRate, reconnectionDelay, maxUnreadMessages);
        thread = new Thread(new ThreadStart(serialThread.RunForever));
        thread.Start();
    }

    void OnDisable()
    {
        if (userDefinedTearDownFunction != null)
            userDefinedTearDownFunction();

        if (serialThread != null)
        {
            serialThread.RequestStop();
            serialThread = null;
        }

        if (thread != null)
        {
            thread.Join();
            thread = null;
        }
    }

    void Update()
    {
        if (messageListener == null)
            return;
        
        string message = (string)serialThread.ReadMessage();
        if (message == null)
            return;

        if (ReferenceEquals(message, SERIAL_DEVICE_CONNECTED))
            messageListener.SendMessage("OnConnectionEvent", true);
        else if (ReferenceEquals(message, SERIAL_DEVICE_DISCONNECTED))
            messageListener.SendMessage("OnConnectionEvent", false);
        else
        {
            string[] values = message.Split(',');
            if (values.Length == 3)
            {
                if (float.TryParse(values[0], out float ax_deg) &&
                    float.TryParse(values[1], out float ay_deg) &&
                    float.TryParse(values[2], out float az_deg))
                {
                    // Call a method to process these values in the message listener
                    messageListener.SendMessage("OnSensorDataReceived", new float[] { ax_deg, ay_deg, az_deg });
                }
            }
            else
            {
                messageListener.SendMessage("OnMessageArrived", message);
            }
        }
    }

    public string ReadSerialMessage()
    {
        return (string)serialThread.ReadMessage();
    }

    public void SendSerialMessage(string message)
    {
        serialThread.SendMessage(message);
    }

    public delegate void TearDownFunction();
    private TearDownFunction userDefinedTearDownFunction;
    public void SetTearDownFunction(TearDownFunction userFunction)
    {
        this.userDefinedTearDownFunction = userFunction;
    }
}
