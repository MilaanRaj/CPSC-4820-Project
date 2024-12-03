using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleTowers : MonoBehaviour
{

    public bool towersActive;
    public GameObject towers;
    
    // Start is called before the first frame update
    void Start()
    {
        towersActive = false;
        if (towers != null)
        {
            towers.SetActive(towersActive);
        }
    }

    public void ToggleTowerVisibility()
    {
        towersActive = !towersActive; 
        if (towers != null)
        {
            towers.SetActive(towersActive); 
        }
    }
}
