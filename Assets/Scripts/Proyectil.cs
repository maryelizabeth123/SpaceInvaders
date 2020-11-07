using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public GameObject proyectil;

    AudioSource fuenteDeAudio;
    public AudioClip audioExplosion;

    // Start is called before the first frame update
    void Start()
    {
        fuenteDeAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 25 * Time.deltaTime,0));
    }

    private void OnCollisionEnter2D(Collision2D miColision) {

        if (miColision.gameObject.tag == "Enemigo" || miColision.gameObject.tag == "proyectilEnemigo") 
        {
            fuenteDeAudio.clip = audioExplosion;
            fuenteDeAudio.Play();

            Destroy(miColision.gameObject);
            Destroy(proyectil);
            GameManager.jugabilidad = true;

            
            if (miColision.gameObject.tag == "Enemigo")
            {
                GameManager.numEnemigos--;
            }
        }

        if (miColision.gameObject.tag == "Campo")
        {
            Destroy(proyectil);
        }
    }
}
