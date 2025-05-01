using System.Collections; // Import this for IEnumerator
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public GameObject redLight;
    public GameObject greenLight;
    public Collider detectionZone; // A collider to detect vehicles at the traffic light

    private void Start()
    {
        StartCoroutine(ControlTraffic());
    }

    private IEnumerator ControlTraffic()
    {
        while (true)
        {
            // Red light on
            redLight.SetActive(true);
            greenLight.SetActive(false);
            StopVehiclesInZone();
            yield return new WaitForSeconds(5); // Wait for 5 seconds

            // Green light on
            redLight.SetActive(false);
            greenLight.SetActive(true);
            ResumeVehiclesInZone();
            yield return new WaitForSeconds(5); // Wait for 5 seconds
        }
    }

    private void StopVehiclesInZone()
    {
        foreach (var vehicle in Physics.OverlapBox(detectionZone.bounds.center, detectionZone.bounds.extents))
        {
            if (vehicle.CompareTag("Vehicle"))
            {
                vehicle.GetComponent<VehicleBehavior>()?.StopVehicle();
            }
        }
    }

    private void ResumeVehiclesInZone()
    {
        foreach (var vehicle in Physics.OverlapBox(detectionZone.bounds.center, detectionZone.bounds.extents))
        {
            if (vehicle.CompareTag("Vehicle"))
            {
                vehicle.GetComponent<VehicleBehavior>()?.ResumeVehicle();
            }
        }
    }
}