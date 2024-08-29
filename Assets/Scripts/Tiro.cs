using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float velocidade;
    public int dano;
    public int dirTiro;

    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine("Contador");
        transform.position += new Vector3(dirTiro * velocidade * Time.deltaTime, 0, 0);
    }

    private IEnumerator Contador()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }

    public void DirecaoTiro(int dir)
    {
        dirTiro = dir;
    }
}
