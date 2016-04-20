using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
//	enum Fade {In, Out}
//	float fadeTime = 4.0F;


	public GameObject PauseUI;
	private bool paused = false;

	// Use this for initialization
	void Start()
	{

		PauseUI.SetActive(false);


	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetButtonDown("Pause"))
		{
			paused = !paused;
		}
		if (paused)
		{
			PauseUI.SetActive(true);
			Time.timeScale = 0;
		}

		if (!paused)
		{
			PauseUI.SetActive(false);
			Time.timeScale = 1;
		}

	}


	public void Resume()
	{
		paused = false;
	}

	public void NewGame()
	{
//		StartCoroutine (FadeAudio (fadeTime, Fade.Out));
//		System.Threading.Thread.Sleep(5000);
		Application.LoadLevel(1);

	}

//	IEnumerator FadeAudio (float timer, Fade fadeType) {
//		float start = fadeType == Fade.In? 0.0F : 1.0F;
//		float end = fadeType == Fade.In? 1.0F : 0.0F;
//		float i = 0.0F;
//		float step = 1.0F/timer;

//		while (i <= 1.0F) {
//			i += step * Time.deltaTime;
//			GetComponent<AudioSource>().volume = Mathf.Lerp(start, end, i);
//			yield return new WaitForSeconds(step * Time.deltaTime);
//		}
//	}
	public void Quit()
	{
		Application.Quit();
	}

	public void MainMenu()
	{
		Application.LoadLevel (0);
	}



}