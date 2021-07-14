using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    //bool moveAllowed;

    //bool isOverPeople;

    //Collider2D col;

    Touch touch;

    //[SerializeField] Transform maskInventory;

    private void Start()
    {
        //col = GetComponent<Collider2D>();
    }

    void Update()
    {
        DragObject();
    }

    void DragObject()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);

                if(touchedCollider.CompareTag("People"))
				{
                    touchedCollider.GetComponent<People>().TakeMask();
				}
            }
            if (touch.phase == TouchPhase.Moved)
            {

            }
            if(touch.phase == TouchPhase.Ended)
			{

            }
		}
    }

	//private void OnTriggerEnter2D(Collider2D collision)
	//{
	//	if(collision.CompareTag("People"))
	//	{
            
	//	}
	//}

	//private void OnTriggerStay2D(Collider2D collision)
	//{
 //       if (collision.CompareTag("People"))
 //       {
 //           if (touch.phase == TouchPhase.Ended)
 //           {
 //               collision.GetComponent<People>().MaskGiven();
 //               transform.position = new Vector2(maskInventory.position.x,maskInventory.position.y);
 //               return;
 //           }
 //       }
 //   }

	//private void OnTriggerExit2D(Collider2D collision)
	//{

	//}
}
