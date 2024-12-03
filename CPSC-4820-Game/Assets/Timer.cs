using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public bool countDown;
    [SerializeField] float time;
    [SerializeField] float timeAllowed;

    public GameObject winCanvas;
    [SerializeField] Canvas UICanvas;
    bool isRunning = false;
    
    public void Start(){
        isRunning = true;
    }
    private void Update(){
        if(isRunning){
            if(countDown){
                time -= Time.deltaTime;
                if (time <= 0){
                    UICanvas.gameObject.SetActive(false);
                    TriggerWinCondition();
                    StopTimer();
                }
                Format();
            }
            
            else{
                time += Time.deltaTime;
                if (time >= timeAllowed){
                    UICanvas.gameObject.SetActive(false);
                    TriggerWinCondition();
                    StopTimer();
                }
                Format();
            }
        }
    }

    public void StartTimer(){
        isRunning = true;
    }

    public void StopTimer(){
        isRunning = false;
    }

    private void Format(){
        int minutes = Mathf.FloorToInt(time / 60); // Get minutes
        int seconds = Mathf.FloorToInt(time % 60); // Get seconds
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Format as MM:SS
    }
    private void TriggerWinCondition()
    {
        // Activate the Lose Canvas
        winCanvas.SetActive(true);
        Debug.Log("Game Over! Win Canvas displayed.");
    }
}
