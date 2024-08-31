using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public Vector3 posInicial;
    //public Vector3 target;
    //public float velocidade;
    //public float distancia;

    //[SerializeField] float moveSpeed;
    //private Rigidbody2D rb;

    void Start()
    {
        posInicial = transform.position;
        //target = posInicial;

        //rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*float step = velocidade * Time.deltaTime;

        Vector3 difTarget = new Vector3(target.x, target.y - distancia, 0);

        transform.position = Vector3.MoveTowards(transform.position, difTarget, step);

        if(Vector3.Distance(transform.position, difTarget) < 0.001f)
        {
            target.y *= -1.0f;
        }*/

        /*if(transform.position.y >= 4.8f)
        {
            rb.velocity = new Vector2(0f, moveSpeed);
            ChegouEmCima();
        }
        else
        {
            rb.velocity = new Vector2(0f, -moveSpeed);
            ChegouEmBaixo();
        }*/

    }

    /*private bool EstaViradoParaCima()
    {
        return transform.position.y > Mathf.Epsilon;
    }

    private void ChegouEmCima()
    {
        if (transform.position.y >= -4.4f)
        {
            transform.position = new Vector2(transform.position.x, -transform.position.y);
        }
    }

    private void ChegouEmBaixo()
    {
        if (transform.position.y <= -4.9f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }*/

    public Vector3 BolaPositionInicial()
    {
        return posInicial;
    }
}
