using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveH;
    public int velocidade;
    public int forcaPulo;
    public bool estaPulando = false;
    public Vector3 posInicial;
    private Rigidbody2D rb;

    void Start()
    {
        posInicial = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !estaPulando)
        {
            rb.AddForce(transform.up * forcaPulo,ForceMode2D.Impulse);
            estaPulando = true;
        }
    }

     private void FixedUpdate() 
    {
        moveH = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveH * velocidade * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            estaPulando = false;
        }
    }
}
