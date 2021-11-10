using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public float remainder;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;
    public LevelTimer time;

    public float EndingTimer;
    public GameObject exitBackground;
    public GameObject winBackground;
    public GameObject Timer;

    public GameObject OneStar;
    public GameObject TwoStar;
    public GameObject ThreeStar;
    public GameObject NoStar;
    public TextMeshProUGUI secondsText;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;
    public bool pickedupitem = false;

    public int keys = 0;

    private void Start()
    {
        OneStar.SetActive(false);
        TwoStar.SetActive(false);
        ThreeStar.SetActive(false);
        NoStar.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log(keys); 
            if (keys == 3)
            {
                m_IsPlayerAtExit = true;
                time.Stop = true;
            }
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
                EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
            EndingTimer -= 1 * Time.deltaTime;
            if (EndingTimer <= 0)
            {
                SceneManager.LoadScene(0);
                Debug.Log("Restart");
            }
        }
        if (time.currentTime <= 0)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
           if (m_IsPlayerCaught == true)
            {
                NoStar.SetActive(true);
                exitBackground.SetActive(false);
                Timer.SetActive(false);
            }
           if (m_IsPlayerCaught == false & m_IsPlayerAtExit == true)
            {
                winBackground.SetActive(false);
                Timer.SetActive(false);

                remainder = time.startingTime - time.currentTime;
                secondsText.text = "You beat the level in " + remainder.ToString("0") + " seconds";

                if (time.currentTime <= 25)
                {
                    NoStar.SetActive(true);
                }
                if (time.currentTime <= 40)
                {
                    OneStar.SetActive(true);
                }
                if (time.currentTime <= 60)
                {
                    TwoStar.SetActive(true);
                }
                if (time.currentTime >= 70)
                {
                    ThreeStar.SetActive(true);
                }

                EndingTimer -= 1 * Time.deltaTime;
                if (EndingTimer <= 0)
                {
                    SceneManager.LoadScene(0);
                    Debug.Log("Restart");
                }
            }
        }
    }
}