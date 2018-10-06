using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myAvatar : MonoBehaviour {

    private Transform myTrasform;
    public float velocidad;
    private float xAxis, zAxis;

    // Use this for initialization
    void Start()
    {
        myTrasform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(-zAxis, 0, xAxis);
        myTrasform.Translate(movement * velocidad);

        if (Input.GetKey(KeyCode.X))
        {
            transform.Translate(0, Time.deltaTime * 6, 0);

        }
       
    }
}
