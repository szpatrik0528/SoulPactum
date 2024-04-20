using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotPoints : MonoBehaviour
{
    private float fallDelay = 0.2f;
    private float destroyDelay = 1f;
    private float Gr = -0.1f;

    [SerializeField] private Rigidbody2D rb;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(floated());
        }

    }
    public IEnumerator floated()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}