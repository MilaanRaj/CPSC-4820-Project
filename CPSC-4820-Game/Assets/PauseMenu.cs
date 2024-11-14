using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject ui;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyUp(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }
}
