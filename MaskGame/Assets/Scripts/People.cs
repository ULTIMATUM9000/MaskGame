using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
	SpriteRenderer spriteRenderer;

	Sprite[] unmaskedSprite;
	Sprite[] maskedSprite;

	int spriteIndex;

	int numOfMaximumTaps;

	int numOfCurrentTaps;

	bool hasMask = false;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		unmaskedSprite = Resources.LoadAll<Sprite>("Unmasked");
		maskedSprite = Resources.LoadAll<Sprite>("Masked");
	}

	private void OnEnable()
	{
		numOfMaximumTaps = Random.Range(1, 4);
		numOfCurrentTaps = 0;
		spriteIndex = Random.Range(0, unmaskedSprite.Length - 1);
		spriteRenderer.sprite = unmaskedSprite[spriteIndex];
	}

	public void TakeMask()
	{
		if(numOfCurrentTaps < numOfMaximumTaps)
		{
			numOfCurrentTaps++;
		}
		if (numOfCurrentTaps == numOfMaximumTaps && !hasMask)
		{
			GameManager.Instance.score++;
			spriteRenderer.sprite = maskedSprite[spriteIndex];
			hasMask = true;
			Invoke("SetActiveFalseObject", 3f);
		}
		else
			return;
	}

	void SetActiveFalseObject()
	{
		gameObject.SetActive(false);
	}
}
