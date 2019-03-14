using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myAvatar : MonoBehaviour {

    private Vector3 moveVelocity;
    public float velocidad;
    private float xAxis, zAxis;
    private Camera mainCamera;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.velocity = moveVelocity;
        rb.MovePosition(transform.position + moveVelocity);
    }
    private void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xAxis, 0, zAxis);
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0;
        Quaternion cameraRelativeRotacion = Quaternion.FromToRotation(Vector3.forward, cameraForward);
        Vector3 lookToward = cameraRelativeRotacion * movement;
        if (movement.sqrMagnitude > 0)
        {
            Ray lookRay = new Ray(transform.position, lookToward);
            transform.LookAt(lookRay.GetPoint(1));
        }
        moveVelocity = transform.forward * velocidad * Time.deltaTime * movement.sqrMagnitude;

        if (Input.GetKeyDown(KeyCode.X))
        {
            
            rb.AddForce(Vector3.up * 200);
        }

    }

   
}
