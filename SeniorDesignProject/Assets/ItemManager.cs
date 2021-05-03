using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static ItemManager itemManager;
    int score;
    
    void Start() 
    {
        if(itemManager == null)
        {
            itemManager = this;
        }
        
    }
    public void UpdateScore(int value)
    {
        score += value;
        text.text = "\u00D7 " + score.ToString();
    }
}
