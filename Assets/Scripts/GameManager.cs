using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int vidas = 3;
    public static int numEnemigos = 18;
    public static bool jugabilidad = true;


    private void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Juego");
        }
    }
}
