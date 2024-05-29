using UnityEngine;

public class MessageReceiver_custom : MonoBehaviour
{
    public float X;
    public float Y;
    public float Z;
    void OnSensorDataReceived(float[] sensorData)
    {
        float ax_deg = sensorData[0];
        float ay_deg = sensorData[1];
        float az_deg = sensorData[2];

        Debug.Log($"Received sensor data: X={ax_deg}, Y={ay_deg}, Z={az_deg}");
        X = ax_deg;
        Y = ay_deg;
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
