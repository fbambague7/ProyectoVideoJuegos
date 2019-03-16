using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerContador : MonoBehaviour
{
    public Text contador;
    public Text fin;
    private float Tiempo = 60f;
    float contadorSegundos = 0;
    float segundosTotales = 5;
    // Start is called before the first frame update
    void Start()
    {
        contador.text = "" + Tiempo;
        fin.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //esperar el tiempo en que demoran las cajan en caer a su posicion
        contadorSegundos += Time.deltaTime;
        if (contadorSegundos >= segundosTotales)
        {
            contadorSegundos = 5;
        }
        //Disminuye tiempo
        if (contadorSegundos == 5)
        {
            Tiempo -= Time.deltaTime;
            contador.text = "" + Tiempo.ToString("f0");
            if (Tiempo <= 0)
            {
                contador.text = "0";
                fin.enabled = true;
                CargaNivel("GameOver");
            }
        }

    }
    public void CargaNivel(string pNombreNivel)
    {
        SceneManager.LoadScene(pNombreNivel);
    }
}
