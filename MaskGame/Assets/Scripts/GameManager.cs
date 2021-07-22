using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject SpawnedObjects;

    public Slider InfectionBar;

    float peopleNoMask;

    public int score;

    [SerializeField] float damage;
    float InfectionMeter = 0f;
	float MaxInfectionMeter = 100f;

	private void Update()
	{
        CalculateHasNoMask();
        IncreaseInfection();

		scoreText.text = "SCORE: " + score.ToString();
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
        InfectionMeter += (damage + (0.01f * peopleNoMask)) * Time.deltaTime;

        if (InfectionBar != null)
            InfectionBar.value = InfectionMeter;

        if (InfectionMeter >= MaxInfectionMeter)
            SceneManager.LoadScene("GameOver");
    }
}
