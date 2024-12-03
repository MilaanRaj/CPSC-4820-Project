using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthText : MonoBehaviour
{
    [SerializeField] TMP_Text healthTxt;
    public  healthBar healthObj;
    
    void Start(){
        healthTxt.text = "20";
    }
    void Update(){
        healthTxt.text = (healthObj.health).ToString();
    }
}