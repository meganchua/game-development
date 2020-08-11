using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
	public Text beginText;

	// Start is called before the first frame update
	void Start()
    {
		StartCoroutine(Countdown(3));
	}

	IEnumerator Countdown(int seconds)
	{
		int count = seconds;
		while (count > 0)
		{
			beginText.text = count.ToString();
			// display something...
			yield return new WaitForSeconds(1);
			count--;
		}

		// count down is finished...
		StartGame();
	}

    void StartGame()
	{
		SceneManager.LoadScene("Game_Scene");
	}
}
