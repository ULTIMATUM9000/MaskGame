using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RetryGame(string sceneName)
    {
        GameManager.instance.InitializeGame();
        CanvasManager.instance.SwitchCanvas(CanvasType.GameUI);
        AudioManager.instance.Play("GameBGM");
        SceneManager.LoadScene(sceneName);
    }
    public void MainMenu(string sceneName)
    {
        CanvasManager.instance.SwitchCanvas(CanvasType.MainMenu);
        AudioManager.instance.Play("MainMenuBGM");
        SceneManager.LoadScene(sceneName);
    }
}
