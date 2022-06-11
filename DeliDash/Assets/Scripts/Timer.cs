using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 300f;

    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1* Time.deltaTime;
        countdownText.text = currentTime.ToString("00:00.00");

        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene("Ending");
        }
    }
}
