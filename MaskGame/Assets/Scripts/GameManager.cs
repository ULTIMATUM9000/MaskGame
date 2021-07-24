using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] TextMeshProUGUI gameOverScore;

    [SerializeField] GameObject SpawnedObjects;

    public Slider InfectionBar;

    float peopleNoMask;

    public int score;

    //public bool gameStart = false;

    //public bool gameOver = false;

    [SerializeField] float damage;
    float InfectionMeter = 0f;
	float MaxInfectionMeter = 100f;

	private void Update()
	{
        if(SceneManager.GetActiveScene().buildIndex == 1)
		{
            SpawnedObjects = GameObject.Find("SpawnManager");
            CalculateHasNoMask();
            IncreaseInfection();
            scoreText.text = "SCORE: " + score.ToString();
        }

        if(SceneManager.GetActiveScene().buildIndex == 2)
		{
            gameOverScore.text = "SCORE: " + score.ToString();
        }            
    }

    public void InitializeGame()
	{
        score = 0;
        InfectionMeter = 0f;
	}

    void CalculateHasNoMask()
	{
        peopleNoMask = 0;

        foreach(Transform child in SpawnedObjects.transform)
		{
            if(!child.GetComponent<People>().hasMask && child.gameObject.activeSelf)
			{
                peopleNoMask++;
			}
		}
    }

    public void IncreaseInfection()
    {
        if(InfectionMeter < MaxInfectionMeter)
		{
            InfectionMeter += (damage + (0.01f * peopleNoMask)) * Time.deltaTime;
        }
        
        if (InfectionBar != null)
            InfectionBar.value = InfectionMeter;

        if (InfectionMeter >= MaxInfectionMeter)
		{
            CanvasManager.instance.SwitchCanvas(CanvasType.GameOver);
            AudioManager.instance.Stop("GameBGM");
            AudioManager.instance.Play("GameOverSFX");
            SceneManager.LoadScene("GameOver");
        }
            
    }
}
