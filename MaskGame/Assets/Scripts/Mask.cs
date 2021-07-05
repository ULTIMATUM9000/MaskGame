using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    void Update()
    {
        DragMask();
    }

    void DragMask()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Screen Touched");
            }
            if(touch.phase == TouchPhase.Moved)
			{

			}
        }
    }
}
