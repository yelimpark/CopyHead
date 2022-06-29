using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityMove : MonoBehaviour
{
    public enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    public float speed;
    public Direction direction;
    public float randomRange = 0;
    public float minPos;
    public float maxPos;

    private void Start()
    {
        speed += Random.Range((-1)* randomRange, randomRange);
    }

    void Update()
    {
        switch(direction)
        {
            case Direction.LEFT:
                transform.position -= Vector3.right * speed  * Time.deltaTime;
                if (transform.position.x < minPos)
                {
                    Vector3 pos = transform.position;
                    pos.x = maxPos;
                    transform.position = pos;
                }
                break;
            case Direction.RIGHT:
                transform.position += Vector3.right * speed * Time.deltaTime;
                if (transform.position.x < maxPos)
                {
                    Vector3 pos = transform.position;
                    pos.x = minPos;
                    transform.position = pos;
                }
                break;
            case Direction.UP:
                transform.position += Vector3.up * speed * Time.deltaTime;
                if (transform.position.x < minPos)
                {
                    Vector3 pos = transform.position;
                    pos.x = maxPos;
                    transform.position = pos;
                }
                break;
            case Direction.DOWN:
                transform.position -= Vector3.up * speed * Time.deltaTime;
                transform.position += Vector3.right * speed * Time.deltaTime;
                if (transform.position.x < maxPos)
                {
                    Vector3 pos = transform.position;
                    pos.x = minPos;
                    transform.position = pos;
                }
                break;
            default:
                break;
        }
    }
}
