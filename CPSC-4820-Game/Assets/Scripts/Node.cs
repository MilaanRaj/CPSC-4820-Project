using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("Can't place turret. Todo - Display on Screen");
            return;
        }

        //Build a turret
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        GetComponent<Renderer>().material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
