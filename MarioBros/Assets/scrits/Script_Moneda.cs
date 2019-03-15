using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Moneda : MonoBehaviour {

    // Use this for initialization
    public GameObject cubo;
    public GameObject moneda;
    GameObject monedaClon;
    public float fuerzaSalto;
    private int numMonedas;



    // Update is called once per frame

    void Update() {

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("mario"))
        {
            saltarMonedas();
            numMonedas = numMonedas + 1;

        }
        if (numMonedas >= 5) {
            Destroy(gameObject, .10f);
           // 
        }

    }
    void saltarMonedas() {
        monedaClon = Instantiate(moneda, cubo.GetComponent<Transform>().position, Quaternion.identity);
        monedaClon.GetComponent<Rigidbody>().AddForce(new Vector3(0,fuerzaSalto,0));
        Destroy(monedaClon,.50f);



        
    }
}
