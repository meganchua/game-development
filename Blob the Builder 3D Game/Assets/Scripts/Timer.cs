using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    
    float startTime = 10f;
    float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        timerText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
            //Application.Quit();
        }
    }
}
