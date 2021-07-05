using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeoplePatrol : MonoBehaviour
{
    float minX, maxX, minY, maxY;
    Vector2 targetPosition;

    public float speed;

    Vector2 gameBorder;
    public float borderAllowance = 1.5f;

    void Start()
    {
        targetPosition = GetRandomPosition();

        gameBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));

        minX = -gameBorder.x / borderAllowance;
        maxX = gameBorder.x / borderAllowance;
        minY = -gameBorder.y / borderAllowance;
        maxY = gameBorder.y / borderAllowance;
    }

    void Update()
    {


        if ((Vector2)transform.position != targetPosition)
		{
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		}
        else
		{
            targetPosition = GetRandomPosition();
		}
    }

    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.DrawWireCube(Vector2.zero, new Vector2(Mathf.Abs(minX) + maxX, Mathf.Abs(minY) + maxY));
	}
}
