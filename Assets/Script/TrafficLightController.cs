using System.Collections;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public GameObject[] redLights; // Array for red lights
    public GameObject[] yellowLights; // Array for yellow lights
    public GameObject[] greenLights; // Array for green lights

    private void Start()
    {
        StartCoroutine(TrafficLightCycle());
    }

    private IEnumerator TrafficLightCycle()
    {
        while (true)
        {
            // Turn on red lights and turn off others
            SetLights(redLights, true);
            SetLights(yellowLights, false);
            SetLights(greenLights, false);
            yield return new WaitForSeconds(5); // Wait for 5 seconds

            // Turn on yellow lights and turn off others
            SetLights(redLights, false);
            SetLights(yellowLights, true);
            SetLights(greenLights, false);
            yield return new WaitForSeconds(2); // Wait for 2 seconds

            // Turn on green lights and turn off others
            SetLights(redLights, false);
            SetLights(yellowLights, false);
            SetLights(greenLights, true);
            yield return new WaitForSeconds(5); // Wait for 5 seconds
        }
    }

    private void SetLights(GameObject[] lights, bool state)
    {
        foreach (GameObject light in lights)
        {
            light.SetActive(state);
        }
    }
}