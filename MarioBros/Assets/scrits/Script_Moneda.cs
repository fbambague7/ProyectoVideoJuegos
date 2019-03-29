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

    
    bool colisiona = false;
    Animator animator;

    void start()
    {
        
    }


    // Update is called once per frame

    void Update() {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("mario"))
        {
            saltarCubos();
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

    void saltarCubos()
    {
        animator = cubo.gameObject.GetComponent<Animator>();
        this.animator.SetBool("colisiona", true);
        Debug.Log("valor Enter: " + this.animator.GetBool("colisiona"));
        StartCoroutine(Example());
    }

    
    private void onCollisonExit()
    {
        animator = cubo.gameObject.GetComponent<Animator>();
        this.animator.SetBool("colisiona", false);
        Debug.Log("valor Exit: " + this.animator.GetBool("colisiona"));
    }

    IEnumerator Example()
    {
        
        Debug.Log(Time.time);
        yield return new WaitForSeconds(0.15f);
        Debug.Log(Time.time);

        animator = cubo.gameObject.GetComponent<Animator>();
        this.animator.SetBool("colisiona", false);
        Debug.Log("valor Exit: " + this.animator.GetBool("colisiona"));
    }

}
