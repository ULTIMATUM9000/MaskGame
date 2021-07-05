using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    public void MaskGiven()
	{
		GameManager.Instance.score++;
		this.gameObject.SetActive(false);
	}
}
