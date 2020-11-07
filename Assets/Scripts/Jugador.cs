using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    public GameObject jugador;
    public GameObject proyectil;
    public GameObject proyectilClon;

    public Text m_MessageText;
    public Text mensajeVida;

    AudioSource fuenteDeAudio;
    public AudioClip audioShot, audioStart, audioMove;

    // Start is called before the first frame update
    void Start()
    {
        m_MessageText.text = "SPACE INVADERS";
        mensajeVida.text = "" + GameManager.vidas;

        fuenteDeAudio = GetComponent<AudioSource>();

        fuenteDeAudio.clip = audioStart;
        fuenteDeAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        verificar();
        if (GameManager.vidas > 0)
        {
            mover();

            disparar();
        }
    }

    void verificar() {
        if (GameManager.vidas <= 0)
        {
            m_MessageText.text = "¡PERDISTE!";
            mensajeVida.text = "0";

        }
        else if (GameManager.numEnemigos == 0)
        {
            m_MessageText.text = "¡GANASTE!";
        }
        else
        {
            mensajeVida.text = "" + GameManager.vidas;
        }
    }

    void mover() {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            fuenteDeAudio.clip = audioMove;
            fuenteDeAudio.Play();

            transform.Translate(new Vector3(20 * Time.deltaTime, 0, 0));
            m_MessageText.text = string.Empty;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            fuenteDeAudio.clip = audioMove;
            fuenteDeAudio.Play();

            transform.Translate(new Vector3(-20 * Time.deltaTime, 0, 0));
            m_MessageText.text = string.Empty;
        }
    }

    void disparar() {
        if (Input.GetKeyDown(KeyCode.Space) && proyectilClon == null) 
        {
            proyectilClon = Instantiate(proyectil, new Vector3(jugador.transform.position.x, jugador.transform.position.y + 0.6f, 0), jugador.transform.rotation) as GameObject;

            fuenteDeAudio.clip = audioShot;
            fuenteDeAudio.Play();
        }
    }

       
}
