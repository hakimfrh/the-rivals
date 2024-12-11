using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text gameOverText;
    public void setup(String text){
        gameObject.SetActive(true);
        gameOverText.text = text;
    }
}
