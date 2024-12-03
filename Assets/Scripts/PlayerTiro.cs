using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTiro : MonoBehaviour
{
    public GameObject tiro;
    public GameObject mira;
    public GameObject menu;
    public Menu menuScript;
    public bool dirPlayer;
    public int bolas;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        mira = GameObject.Find("Mira");
        menu = GameObject.FindGameObjectWithTag("Menu");
        menuScript = menu.GetComponent<Menu>();
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

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
            audioManager.PlaySFX(audioManager.shoot);
            Atira(dirPlayer);
        }

        if(mira == null)
        {
            mira = GameObject.Find("Mira");
        }

        if(audioManager == null)
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        }

        if (menu == null)
        {
            menu = GameObject.FindGameObjectWithTag("Menu");
        }

        if (menuScript == null)
        {
            menuScript = menu.GetComponent<Menu>();
        }

        if (menuScript.RetornaReplay())
        {
            bolas = 0;
        }

    }

    void Atira(bool direcao)
    {
        bolas--;
        Vector3 offSet1 = new Vector3(mira.transform.position.x + 1.0f, mira.transform.position.y, 0);
        Vector3 offSet2 = new Vector3(mira.transform.position.x - 1.0f, mira.transform.position.y, 0);
        if(direcao)
        {
            Instantiate(tiro, offSet1, Quaternion.Euler(0, 0, 180));
        }
        else
        {
            Instantiate(tiro, offSet2, Quaternion.Euler(0, 0, -180)).GetComponent<Tiro>().DirecaoTiro(-1);
        }
    }

    public void AddBolas()
    {
        bolas++;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            bolas++;
        }
    }

    public int QuantidadeBolas()
    {
        return bolas;
    }
}
