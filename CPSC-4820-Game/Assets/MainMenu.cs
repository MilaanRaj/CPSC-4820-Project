using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string screenToLoad = "Main Menu";
    public void MainMenuAccess ()
    {
        SceneManager.LoadScene(screenToLoad);
    }
}
