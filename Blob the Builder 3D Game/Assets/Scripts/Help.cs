using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Help : MonoBehaviour
{
	public void backButton()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void playButton()
	{
		SceneManager.LoadScene("Begin");
	}
}
