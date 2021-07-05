using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskThrow : MonoBehaviour
{
    [SerializeField] GameObject MaskProjectile;

    void Update()
    {
        ShootMask();
    }

    void ShootMask()
	{
        if(Input.touchCount > 0)
		{
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began)
			{
                Debug.Log("Screen Touched");
			}
		}
	}
}
