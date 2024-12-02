using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointindex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position,target.position)<= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointindex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointindex++;
        target = Waypoints.points[wavepointindex];
        Debug.Log(wavepointindex);
    }
}
