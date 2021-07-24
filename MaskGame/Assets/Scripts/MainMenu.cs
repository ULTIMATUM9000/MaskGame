using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	private void Start()
	{
		AudioManager.instance.Play("MainMenuBGM");
	}
	public void LoadScene(string sceneName)
    {
		GameManager.instance.InitializeGame();
        AudioManager.instance.Stop("MainMenuBGM");
        AudioManager.instance.Play("GameBGM");
        SceneManager.LoadScene(sceneName);
		CanvasManager.instance.SwitchCanvas(CanvasType.GameUI);
	}
}
