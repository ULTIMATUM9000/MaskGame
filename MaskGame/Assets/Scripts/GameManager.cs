using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] TextMeshProUGUI scoreText;

    public int score;
    float InfectionMeter = 100f;

	private void Update()
	{
		scoreText.text = "SCORE: " + score.ToString();
	}
}
