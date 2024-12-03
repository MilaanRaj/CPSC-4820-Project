using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Displays : MonoBehaviour
{
    [System.Serializable]
    public class DisplaySetup
    {
        public Camera displayCamera;    
    }

    public DisplaySetup[] displays;     private int currentDisplayIndex = 0;
    public Canvas playingCanvas;    
    public Canvas other;
    void Start()
    {
        
        ActivateCamera(0);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playingCanvas.gameObject.SetActive(true);
            other.gameObject.SetActive(false);
            ActivateCamera(0); 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playingCanvas.gameObject.SetActive(true);
            other.gameObject.SetActive(false);
            ActivateCamera(1); 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playingCanvas.gameObject.SetActive(false);
            other.gameObject.SetActive(true);
            ActivateCamera(2); 
        }
    }

    private void ActivateCamera(int index)
    {
        if (index < 0 || index >= displays.Length)
        {
            Debug.LogError("Invalid camera index: " + index);
            return;
        }

        
        for (int i = 0; i < displays.Length; i++)
        {
            displays[i].displayCamera.gameObject.SetActive(false);
        }

        displays[index].displayCamera.gameObject.SetActive(true);
        currentDisplayIndex = index;

        Debug.Log("Activated Camera: " + (index + 1));
    }
}
