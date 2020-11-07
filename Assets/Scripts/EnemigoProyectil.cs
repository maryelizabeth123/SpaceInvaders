using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoProyectil : MonoBehaviour
{
    public GameObject enemigoProyectil;
    Vector3 reposicionamiento = new Vector3(-0.5f,-34.5f,0);

    public AudioSource audioLifeLost;

    // Start is called before the first frame update
    void Start()
    {
        audioLifeLost = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Translate(new Vector3(0, -10 * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D miColision)
    {

        if (miColision.gameObject.tag == "Jugador")
        {
            audioLifeLost.Play();

            miColision.gameObject.transform.position = reposicionamiento;
          
            Destroy(enemigoProyectil);
            GameManager.vidas--;
            GameManager.jugabilidad = false;

            
        }

        if (miColision.gameObject.tag == "Campo")
        {
            Destroy(enemigoProyectil);
        }
    }
}
