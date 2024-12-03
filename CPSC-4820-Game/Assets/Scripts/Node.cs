using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private TextMeshProUGUI coinsText;

 
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        
        buildManager = BuildManager.instance;

        //Find the UI element with the tag coins
        GameObject coinsUI = GameObject.FindGameObjectWithTag("coins");
        if (coinsUI != null)
        {
            coinsText = coinsUI.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogWarning("No UI element with tag 'coins' found!");
        }
    }


    void UpdateAmountUI()
    {
        if (coinsText != null)
        {
            coinsText.text = Bullet.kelpCoins.ToString();
        }
    }

    void OnMouseDown()
    {
        // Check if there are enough KelpCoins to place a turret
        if (Bullet.kelpCoins < 10) // Assuming the turret costs 10 coins
        {
            Debug.Log("Not enough KelpCoins to place turret!");
            return;
        }

        // Check if there is a turret selected to build
        if (buildManager.GetTurretToBuild() == null)
        {
            Debug.Log("No turret selected to build!");
            return;
        }

        // Check if a turret is already placed on this spot
        if (turret != null)
        {
            Debug.Log("Can't place turret here. A turret already exists.");
            return;
        }

        // Deduct KelpCoins
        Bullet.kelpCoins -= 10;

        // Update the UI to reflect the new KelpCoins amount
        UpdateAmountUI();

        // Build the turret
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + new Vector3(0, 2.0f, 0), transform.rotation);

        Debug.Log("Placed Turret. Remaining KelpCoins: " + Bullet.kelpCoins);
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
