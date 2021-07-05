using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    bool moveAllowed;

    bool isOverPeople;

    Collider2D col;

    Touch touch;

    [SerializeField] Transform maskInventory;

    private void Start()
    {
        col = GetComponent<Collider2D>();
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
                if(col = touchedCollider)
				{
                    moveAllowed = true;
				}
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if(moveAllowed)
				{
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);

				}
            }
            if(touch.phase == TouchPhase.Ended)
			{
				moveAllowed = false;

                if(!isOverPeople)
				{
                    transform.position = new Vector2(maskInventory.position.x, maskInventory.position.y);
                }
            }
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("People"))
		{
            isOverPeople = true;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.CompareTag("People"))
        {
            if (touch.phase == TouchPhase.Ended)
            {
                collision.GetComponent<People>().MaskGiven();
                transform.position = new Vector2(maskInventory.position.x,maskInventory.position.y);
            }
        }
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
        isOverPeople = false;
	}
}
