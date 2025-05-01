using UnityEngine;

public class PedestrianBehavior : MonoBehaviour
{
    public float speed = 5f; // Speed of pedestrian movement
    public GameObject pedestrianGreenLight; // Pedestrian green light
    public GameObject pedestrianRedLight; // Pedestrian red light
    private bool canCross = false; // Whether the pedestrian is allowed to cross

    private void Update()
    {
        // Check if the pedestrian traffic light is green
        if (pedestrianGreenLight.activeSelf)
        {
            canCross = true;
        }
        else
        {
            canCross = false;
        }

        // Handle player input for movement
        if (canCross)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            // Move the pedestrian based on user input
            transform.Translate(new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check for collision with vehicles
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            Debug.Log("Collision with vehicle! Be careful!");
            // Implement logic to reset the pedestrian's position or end the simulation
        }
    }
}