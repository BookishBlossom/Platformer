using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isHurt = false;

    //SCORE
    private int points = 0;
    public TextMeshProUGUI scoreText;

    //SOUND
    private AudioSource audio;
    public AudioClip jump;
    public AudioClip hurt;
    public AudioClip collect;

    //MOVEMENT
    public float speed;
    private float horizontalInput;

    //JUMPING
    private Rigidbody2D rb;
    private bool isOnFloor = true;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        scoreText.text = "Candles: " + points;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHurt)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);

            if (horizontalInput > 0.01)
            {
                spriteRenderer.flipX = false;
            }
            if (horizontalInput < -0.01)
            {
                spriteRenderer.flipX = true;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isOnFloor)
            {
                Jump();
            }

            if (horizontalInput > 0.01 || horizontalInput < -0.01)
            {
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        }

        animator.SetBool("isOnGround", isOnFloor);
    }

    void Jump()
    {
        audio.PlayOneShot(jump);
        isOnFloor = false;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnFloor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnFloor = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Hurt();
        }
        else if (collision.gameObject.CompareTag("Collectable"))
        {
            audio.PlayOneShot(collect);
            points++;
            scoreText.text = "Candles: " + points;
            Destroy(collision.gameObject);
        }

    }

    public void Hurt()
    {
        if (!isHurt)
        {
            audio.PlayOneShot(hurt);
            isHurt = true;
            animator.SetBool("isHurt", isHurt);
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
