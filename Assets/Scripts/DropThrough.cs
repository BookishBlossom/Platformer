using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropThrough : MonoBehaviour
{
    private Collider2D platformCollider;
    private Collider2D playerCollider;

    private AudioSource audio;
    public AudioClip drop;

    // Start is called before the first frame update
    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && playerCollider != null)
        {
            StartCoroutine(Drop());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCollider = collision.gameObject.GetComponent<Collider2D>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCollider = null;
        }
    }

    IEnumerator Drop()
    {
        audio.PlayOneShot(drop);
        Collider2D ignoredCollider = playerCollider;
        Physics2D.IgnoreCollision(platformCollider, ignoredCollider, true);
        yield return new WaitForSeconds(1);
        Physics2D.IgnoreCollision(platformCollider, ignoredCollider, false);
    }

}
