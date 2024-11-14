using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;

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

    // Use OnTriggerEnter instead of OnCollisionEnter
    void OnTriggerEnter(Collider other)
    {
        // Debug statement to check if the trigger is detected
        Debug.Log("Bullet hit something: " + other.gameObject.name);

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

        // Destroy the enemy
        // Destroy(enemy);

        // Destroy the bullet
        Destroy(gameObject);
    }
}
