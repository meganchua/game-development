using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public void retryButton()
	{
		SceneManager.LoadScene("Begin");
	}

	public void mainMenuButton()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
