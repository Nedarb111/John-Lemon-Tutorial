using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{

    public float currentTime = 0f;
    public float startingTime = 120f;

    public TextMeshProUGUI timerText;
    public bool Stop;


    //setting currentTime = startingTime
    void Start()
    {
        currentTime = startingTime;
    }

    void Update()

    {
        //if the timer hasn't stopped, the timer will keep going
        if (Stop == false)
        {
            //makes the time countdown per second
            currentTime -= Time.deltaTime;
            //writes the time as a string. allows it to be shown in the game.
            timerText.text = "Time Left: " + currentTime.ToString("0");
            //keeps the timer from counting down past 0.
            if (currentTime <= 0)
            {
                currentTime = 0;
                Stop = true;
                //UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
}