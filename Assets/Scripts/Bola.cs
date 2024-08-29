using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public Vector3 posInicial;
    public Vector3 target;
    public float velocidade;
    public float distancia;

    void Start()
    {
        posInicial = transform.position;
        target = posInicial;
    }

    void Update()
    {
        float step = velocidade * Time.deltaTime;

        Vector3 difTarget = new Vector3(target.x, target.y - distancia, 0);

        Debug.Log(difTarget);

        transform.position = Vector3.MoveTowards(transform.position, difTarget, step);

        if(Vector3.Distance(transform.position, difTarget) < 0.001f)
        {
            target.y *= -1.0f;
        }

    }

    public Vector3 BolaPositionInicial()
    {
        return posInicial;
    }
}
