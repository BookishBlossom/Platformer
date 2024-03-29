using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardControlExample : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HazardPlayerController>().Hurt();
        }
    }
}
