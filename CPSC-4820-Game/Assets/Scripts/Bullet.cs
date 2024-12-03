using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;

    public static int kelpCoins = 10;
    public static int score = 0;

    private TextMeshProUGUI coinsText;
    private TextMeshProUGUI scoreText;
    

    void Start()
    {
        // Find the UI element with the tag "coins"
        GameObject coinsUI = GameObject.FindGameObjectWithTag("coins");
        //Find the UI element with the tag "score"
        GameObject scoreUI = GameObject.FindGameObjectWithTag("score");

        if (coinsUI != null)
        {
            coinsText = coinsUI.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogWarning("No UI element with tag 'coins' found!");
        }

        if (scoreUI != null)
        {
            scoreText = scoreUI.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogWarning("No UI element with tag 'score' found!");
        }
    }

    void UpdateAmountUI()
    {
        if (coinsText != null)
        {
            coinsText.text = kelpCoins.ToString();
        }

        if(scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GroundGrid"))
        {
            Debug.Log("Bullet ignored GroundGrid object: " + other.gameObject.name);
            return; // Ignore and exit the method
        }

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Bullet hit an enemy!");

            HitTarget(other.gameObject);  // Pass the enemy that was hit
        }
    }

    void HitTarget()
    {
        // Destroy the bullet itself
        Destroy(gameObject);
    }

    void HitTarget(GameObject enemy)
    {
        // Instantiate an impact effect at the bullet's position
        GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(effectIns, 2f);  // Destroy the effect after 2 seconds

        // Update points
        kelpCoins += 1;
        score += 10;
        UpdateAmountUI();

        // Destroy the enemy
        Destroy(enemy);

        // Destroy the bullet
        Destroy(gameObject);
    }
}
