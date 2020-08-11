using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
	public void playButton()
	{
		SceneManager.LoadScene("Begin");
	}

	public void creditsButton()
	{
		SceneManager.LoadScene("Credits");
	}

	public void helpButton()
	{
		SceneManager.LoadScene("Help");
	}

	public void mainMenuButton()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void quitButton()
	{
		Application.Quit();
	}
}
