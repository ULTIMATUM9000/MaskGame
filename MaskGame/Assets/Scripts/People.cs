using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
	int numOfMaximumTaps;

	int numOfCurrentTaps;

	private void OnEnable()
	{
		numOfMaximumTaps = Random.Range(1, 4);
		numOfCurrentTaps = 0;
	}

	public void TakeMask()
	{
		if(numOfCurrentTaps < numOfMaximumTaps)
		{
			numOfCurrentTaps++;
		}
		if(numOfCurrentTaps == numOfMaximumTaps)
		{
			GameManager.Instance.score++;
			this.gameObject.SetActive(false);
		}
	}
}
