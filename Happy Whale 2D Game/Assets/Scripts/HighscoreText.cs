using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HighscoreText))]
public class HighscoreText : MonoBehaviour
{

    Text highscore;
    // Start is called before the first frame update
    void OnEnable()
    {
        highscore = GetComponent<Text>();
        highscore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

}
