using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMenu : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectClownfishTurret()
    {
        Debug.Log("Clownfish selected.");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }
}
