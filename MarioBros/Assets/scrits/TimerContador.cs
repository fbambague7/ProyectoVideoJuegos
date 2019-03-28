using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerContador : MonoBehaviour
{
    public Text contador;
    public Text fin;
    private float Tiempo = 20f;
    float contadorSegundos = 0;
    float segundosTotales = 5;

    public Animator animFinish;
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
                CargaNivel("GameOver");
            }
        

    }
    //Recordar iniciar la corutina en Start
    public IEnumerator Contar()
    {
        while (true)
        { 
            Tiempo -= 1.0f;
            
            contador.text = "" + Tiempo.ToString("f0");
            if (Tiempo <= 0)
            {
                contador.text = "0";
                fin.enabled = true;
                CargaNivel("GameOver");
                break;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void CargaNivel(string pNombreNivel)
    {

        

        StartCoroutine(FinishYSalir());

    }

    public IEnumerator FinishYSalir()
    {
        animFinish.gameObject.SetActive(true);
        animFinish.Play("finish");

        yield return new WaitUntil(() => animFinish.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);
        print("Termino");
        SceneManager.LoadScene("GameOver");

    }

    
}

