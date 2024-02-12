using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HazardPlayerController : MonoBehaviour
{
    /*
    * This script is designed to provide a simple player controller
    * for the hazard demonstration.
    * 
    *    <3 Pasimio
    */


    //old variables
    public float moveSpeed;
    public float jumpForce;
    private float horizontalInput;
    private Rigidbody2D rb;
    private bool isOnGround = true;


    //new variables go here
    private Animator animator;
    private bool isHurt = false;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHurt)
        {
            //Move
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * horizontalInput);

            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                isOnGround = false;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    public void Hurt()
    {
        if (!isHurt)
        {
            isHurt = true;
            animator.SetBool("isHurt", isHurt);
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        transform.position = spawnPoint.position;
        isHurt = false;
        animator.SetBool("isHurt", isHurt);
    }

}
