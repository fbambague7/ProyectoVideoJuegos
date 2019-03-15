using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerContador : MonoBehaviour
{
    public Text contador;
    public Text fin;
    private float Tiempo = 60f;
    // Start is called before the first frame update
    void Start()
    {
        contador.text = "" + Tiempo;
        fin.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Tiempo -= Time.deltaTime;
        contador.text = "" + Tiempo.ToString("f0");
        if (Tiempo <= 0)
        {
            contador.text = "0";
            fin.enabled = true;
        }
    }
}
