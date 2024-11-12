using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class switchSceneTo : MonoBehaviour
{
    public void MainMenu(){
        SceneManager.LoadSceneAsync("Main Menu");
    }
    public void Tutorial(){
        SceneManager.LoadSceneAsync("Tutorial");
    }

    public void Levels(){
        SceneManager.LoadSceneAsync("Levels");
    }
    
}