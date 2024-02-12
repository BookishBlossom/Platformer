using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetectorExample : MonoBehaviour
{
    public EnemyControlExample enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = transform.parent.GetComponent<EnemyControlExample>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.Hurt();

            //disable the collider
            GetComponent<BoxCollider2D>().enabled = false;

            //Bounce the player
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
    }
}
