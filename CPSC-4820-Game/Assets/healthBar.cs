using UnityEngine;

public class healthBar : MonoBehaviour
{
    public int health = 20; // Starting health
    public GameObject loseCanvas; // Reference to the Lose Canvas

    private void Start()
    {
        // Ensure the lose canvas is hidden at the start
        if (loseCanvas != null)
        {
            loseCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered " );
        // Check if the colliding object is an enemy
        if (other.CompareTag("Enemy"))
        {
            // Decrease health by 1
            health -= 1;
            Debug.Log("Health decreased: " + health);

            // Check if health is zero or less
            if (health <= 0)
            {
                TriggerLoseCondition();
            }
        }
    }

    private void TriggerLoseCondition()
    {
        // Activate the Lose Canvas
        if (loseCanvas != null)
        {
            loseCanvas.SetActive(true);
            Debug.Log("Game Over! Lose Canvas displayed.");
        }
        else
        {
            Debug.LogError("Lose Canvas is not assigned in the Inspector!");
        }
    }
}
