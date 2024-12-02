using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinsText : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    
    public int coins = 10;
    
    void Start(){
        text.text = "10";
    }
    void Update(){
        text.text = coins.ToString();
    }

    public void addScore(){
        coins += 10;
    }
}