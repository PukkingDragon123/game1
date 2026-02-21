using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 200;
    private GameObject focalpoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalpoint = GameObject.Find("Focal point");

    }

    // Update is called once per frame
    void Update()
    {
        float inputy = Input.GetAxis("Vertical");
        rb.AddForce(focalpoint.transform.forward * (inputy * force * Time.deltaTime));

    }
}
