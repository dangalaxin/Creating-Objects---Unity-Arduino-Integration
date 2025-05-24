using System.IO.Ports; // Allows serial communication with Arduino
using UnityEngine;

// This script listens to serial data from an Arduino and spawns cubes in front of a sphere when "DETECTED" is received.
public class CubeSpawner : MonoBehaviour
{
    public GameObject sphere;           // Reference to the sphere in the scene
    public GameObject cubePrefab;       // Prefab of the cube to instantiate
    public string portName = "COM4";    // COM port to which Arduino is connected
    public int baudRate = 9600;         // Baud rate for serial communication

    public float spawnCooldown = 1f;    // Minimum time between two cube spawns
    public float lastSpawnTime = 0f;    // Time when the last cube was spawned

    private SerialPort serial;          // Serial port object for communication

    void Start()
    {
        // Initialize the serial connection
        serial = new SerialPort(portName, baudRate);
        try
        {
            serial.Open();             // Open the serial port
            serial.ReadTimeout = 50;   // Set a read timeout to avoid freezing
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error: " + e.Message); // Log error if port can't be opened
        }
    }

    void Update()
    {
        // Check if the serial connection is active
        if (serial != null && serial.IsOpen)
        {
            try
            {
                // Read data sent from Arduino
                string data = serial.ReadLine().Trim();

                // If "DETECTED" is received and enough time has passed since last spawn
                if (data == "DETECTED" && Time.time - lastSpawnTime >= spawnCooldown)
                {
                    Vector3 forward = sphere.transform.forward; // Direction the sphere is facing

                    // Calculate the spawn position 4 units in front of the sphere
                    Vector3 spawnPos = sphere.transform.position + forward.normalized * 4f;

                    // Instantiate the cube at the calculated position
                    Instantiate(cubePrefab, spawnPos, Quaternion.identity);

                    // Update the last spawn time
                    lastSpawnTime = Time.time;
                }
            }
            catch (System.Exception)
            {
                // Ignore read timeout errors
            }
        }
    }

    void OnApplicationQuit()
    {
        // Properly close the serial port when the application quits
        if (serial != null && serial.IsOpen)
            serial.Close();
    }
}
