using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce (Vector3.up * force, ForceMode.Impulse);
        float randomForce = Random.Range(-force, force);
        Vector3 torque = new Vector3(randomForce, randomForce, randomForce);
        rb.AddTorque(torque, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
