using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class SerialBiometricController : MonoBehaviour
{
    public Text statusText;
    SerialPort serial = new SerialPort("COM3", 9600);

    void Start() {
        serial.Open();
        serial.ReadTimeout = 100;
    }

    void Update() {
        try {
            string data = serial.ReadLine();
            if (data.Contains("UNLOCK")) {
                statusText.text = "Access Granted";
                statusText.color = Color.green;
                // Add lock opening symbol
            } else if (data.Contains("DENIED")) {
                statusText.text = "Access Denied";
                statusText.color = Color.red;
            }
        } catch (System.Exception) {}
    }
}
