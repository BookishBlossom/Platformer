using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetectorExample : MonoBehaviour
{
    private EnemyControlExample enemy;

    // Start is called before the first frame update
    void Start()
    {
        //find the parent script
        enemy = transform.parent.GetComponent<EnemyControlExample>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.2f);

        if (hit.collider == null)
        {
            enemy.Turn();
        }
        /*else if(!hit.collider.gameObject.CompareTag("Ground"))
        {
            enemy.Turn();
        }*/
    }
}
