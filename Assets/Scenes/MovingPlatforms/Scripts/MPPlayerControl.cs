using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MPPlayerControl : MonoBehaviour
{
    /*
     * This script is designed to provide a simple player controller
     * for the moving platform demonstration.
     * 
     *    <3 Pasimio
     */

    public float moveSpeed;
    public float jumpForce;
    private float horizontalInput;
    private Rigidbody2D rb;
    private bool isOnGround = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Move
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * horizontalInput);

        //Jump
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
