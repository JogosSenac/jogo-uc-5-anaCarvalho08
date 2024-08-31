using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveH;
    public int velocidade;
    public int forcaPulo;
    public bool estaPulando = false;
    public bool estaVivo = true;
    public int vida = 1;
    public Vector3 posInicial;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private PlayerTiro tiro;
    public GameObject prefab;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        tiro = GameObject.FindObjectOfType<PlayerTiro>().GetComponent<PlayerTiro>();
    }

    void Start()
    {
        posInicial = transform.position;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !estaPulando)
        {
            audioManager.PlaySFX(audioManager.jump);
            rb.AddForce(transform.up * forcaPulo,ForceMode2D.Impulse);
            estaPulando = true;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            sprite.flipX = false;
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            sprite.flipX = true;
        }

        if(vida<=0)
        {
            estaVivo = false;
        }
        /*if(!estaVivo)
        {
            Destroy(this.gameObject);
            Instantiate(prefab, PlayerPositionInicial(), Quaternion.identity);
            player = GameObject.FindGameObjectWithTag("Player");
            playerMovement = player.GetComponent<PlayerMovement>();
        }*/
        
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

        if(other.gameObject.CompareTag("PassaFase1"))
        {
            SceneManager.LoadScene ("Fase2");
        }

        if(other.gameObject.CompareTag("PassaFase2"))
        {
            SceneManager.LoadScene("Fase3");
        }

        if(other.gameObject.CompareTag("Buraco"))
        {
            estaVivo = false;
            //Destroy(this.gameObject);
        }

        if(other.gameObject.CompareTag("Boss"))
        {
            vida--;
        }

        if(other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            tiro.AddBolas();
        }
    }

    public bool VerificaSePlayerEstaVivo()
    {
        return estaVivo;
    }

    public Vector3 PlayerPositionInicial()
    {
        return posInicial;
    }
}
