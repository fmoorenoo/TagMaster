using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private GameObject exitButton; 
    public float timer = 51;
    public TextMeshProUGUI timerText;
    private TextMeshProUGUI levelText;


    void Start()
    {
        exitButton = GameObject.FindWithTag("ExitButton");
        levelText = LevelUtilities.FindLevelText();
    }
    void Update()
    {

        if (timer > 0 && levelText.text != "¡Has ganado!")
        {
            timer -= Time.deltaTime;
            timer = Mathf.Max(0, timer);
            
        } else if (timer <= 0) {
            exitButton.transform.localPosition = new Vector3(0, -205, 0);
            levelText.text = "¡Has perdido!";
        }

        timerText.text = timer.ToString("F1");
    }
}
