using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one build manager");
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;

    private GameObject turretToBuild;


    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
