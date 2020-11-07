using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    float temporizador = 0;
    float tiempoMoverse = 1f;
    int numeroMovimiento = 0;
    float velocidad = 4f;

    public GameObject enemigo;
    public GameObject enemigoProyectil;
    public GameObject enemigoProyectilClon;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.jugabilidad)
        {
            if (numeroMovimiento == 14)
            {
                transform.Translate(new Vector3(0, -4f, 0));
                numeroMovimiento = 0;
                velocidad = -velocidad;
                temporizador = 0;
            }

            temporizador += Time.deltaTime;

            if (temporizador > tiempoMoverse)
            {

                transform.Translate(new Vector3(velocidad, 0, 0));
                temporizador = 0;
                numeroMovimiento++;
            }

            enemigoDisparar();
        }
    }

    void enemigoDisparar()
    {
        if (Random.Range(0f,1000f) < 1)
        {
            enemigoProyectilClon = Instantiate(enemigoProyectil, new Vector3(enemigo.transform.position.x, enemigo.transform.position.y + 0.6f, 0), enemigo.transform.rotation) as GameObject;
        }
    }
}
