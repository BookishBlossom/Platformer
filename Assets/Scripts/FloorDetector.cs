using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetector : MonoBehaviour
{
    private EnemyController enemy;

    // Start is called before the first frame update
    void Start()
    {
        //find the parent script
        enemy = transform.parent.GetComponent<EnemyController>();
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
