using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class waveText : MonoBehaviour
{
    [SerializeField] TMP_Text wave;
    public  WaveSpawner waveNum;
    
    void Start(){
        wave.text = "0";
    }
    void Update(){
        wave.text = (waveNum.waveNumber - 1).ToString();
    }
}