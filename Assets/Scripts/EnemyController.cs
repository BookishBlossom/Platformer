using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private bool isHurt = false;
    private Animator animator;


    public AudioClip crunch;
    private AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHurt)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    //Physics2D.Raycast()
    //RaycastHit

    public void Turn()
    {
        transform.Rotate(Vector2.up, 180);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().Hurt();
        }
    }

    public void Hurt()
    {
        isHurt = true;
        animator.SetBool("isHurt", isHurt);

        audio.PlayOneShot(crunch);
        //disable the enemy
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;

        Destroy(gameObject, 1);
    }
}
