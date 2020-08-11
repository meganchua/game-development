using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playButton()
	{
		SceneManager.LoadScene("Begin");
	}

    public void creditsButton()
	{
		SceneManager.LoadScene("Credits");
	}

    public void quitButton()
	{
		Application.Quit();
	}

    public void helpButton()
	{
		SceneManager.LoadScene("Help");
	}
}
