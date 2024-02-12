using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetector : MonoBehaviour
{
    public EnemyController enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = transform.parent.GetComponent<EnemyController>();
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

            //Bounce the player
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);

            //disable the collider
            GetComponent<BoxCollider2D>().enabled = false;

            
        }
    }
}
