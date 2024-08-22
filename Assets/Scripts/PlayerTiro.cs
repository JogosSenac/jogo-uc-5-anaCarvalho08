using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTiro : MonoBehaviour
{
    public GameObject tiro;
    public GameObject mira;
    public bool dirPlayer;
    public int bolas;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.A))
        {
            dirPlayer = false;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            dirPlayer = true;
        }

        if(Input.GetMouseButtonDown(0) && bolas>0)
        {
            Atira(dirPlayer);
        }
    }

    void Atira(bool direcao)
    {
        bolas --;
        if(direcao)
        {
            Instantiate(tiro, mira.transform.position, Quaternion.Euler(0, 0, 180));
        }
        else
        {
            Instantiate(tiro, mira.transform.position, Quaternion.Euler(0, 0, -180)).GetComponent<Tiro>().DirecaoTiro(-1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            bolas ++;
        }
    }
}
