using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    private Vector2 startPos;
    private float newX;
    private float newY;

    [Header("Horizontal Settings")]
    public bool isMovingHorizontally;
    public float xAmp = 1;
    public float xPeriod = 1;
    public bool isUsingCosX;

    [Header("Vertical Settings")]
    public bool isMovingVertically;
    public float yAmp = 1;
    public float yPeriod = 1;
    public bool isUsingCosY;

    // Start is called before the first frame update
    void Start()
    {
        //Get the start position
        startPos = transform.position;

        newX = startPos.x;
        newY = startPos.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal Movement
        if(isMovingHorizontally)
        {
            if(!isUsingCosX)
            {
                newX = startPos.x + (xAmp * Mathf.Sin((6.28f / xPeriod) * Time.time));
            }
            else
            {
                newX = startPos.x + (xAmp * Mathf.Cos((6.28f / xPeriod) * Time.time));
            }
        }

        //Vertical Movement
        if (isMovingVertically)
        {
            if (!isUsingCosY)
            {
                newY = startPos.y + (yAmp * Mathf.Sin((6.28f / yPeriod) * Time.time));
            }
            else
            {
                newY = startPos.y + (yAmp * Mathf.Cos((6.28f / yPeriod) * Time.time));
            }
        }

        //Update the position
        transform.position = new Vector2(newX, newY);

    }
}
