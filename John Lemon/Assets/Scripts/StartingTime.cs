using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartingTime : MonoBehaviour
{

    public float currentTime = 0f;
    public float startingTime = 120f;
    public GameObject instructions;
    public LevelTimer leveltimer;

    //setting currentTime = startingTime
    void Start()
    {
        currentTime = startingTime;
    }

    void Update()

    {
        //makes the time countdown per second
        currentTime -= Time.deltaTime;

        //keeps the timer from counting down past 0.
        if (currentTime <= 0)
        {
            currentTime = 0;
            instructions.SetActive(false);
            leveltimer.starttimer = true;
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
