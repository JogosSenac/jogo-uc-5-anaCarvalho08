using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;
    public int vida = 3;


    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(EstaViradoParaDir())
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
            transform.localScale = new Vector3(2, 2, 1);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
            transform.localScale = new Vector3(-2, 2, 1);
        }

        if(vida<=0)
        {
            Destroy(this.gameObject);
        }
    }

    private bool EstaViradoParaDir()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            vida--;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
    }
}
