using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public Vector3 posInicial;

    void Start()
    {
        transform.position = posInicial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 BolaPositionInicial()
    {
        return posInicial;
    }
}
