using UnityEngine;

public class MessageReceiver_custom : MonoBehaviour
{
    public float Y1;
    public float Y2;
    public float Z;
    void OnSensorDataReceived(float[] sensorData)
    {
        float ax_deg = sensorData[0];
        float ay_deg = sensorData[1];
        float az_deg = sensorData[2];

        Debug.Log($"Received sensor data: X={ax_deg}, Y={ay_deg}, Z={az_deg}");
        Y1 = ax_deg;
        Y2 = ay_deg;
        Z = az_deg;
    }

    void OnMessageArrived(string message)
    {
        Debug.Log($"Message arrived: {message}");
    }

    void OnConnectionEvent(bool isConnected)
    {
        Debug.Log($"Connection event: {(isConnected ? "Connected" : "Disconnected")}");
    }
}
