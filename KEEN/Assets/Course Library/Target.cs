using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 10;
    public float forcex = 3;
    public bool bomb = false;
    public ParticleSystem explode;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 randompos = new Vector3(Random.Range(-forcex, forcex), transform.position.y, transform.position.z);
        transform.position = randompos;
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        float randomForce = Random.Range(-force, force);
        Vector3 torque = new Vector3(randomForce, randomForce, randomForce);
        rb.AddTorque(torque, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1)
        {

            Destroy(gameObject);


        }
    }
    private void OnMouseDown()
    {
        Debug.Log("CLICKED");
        Instantiate(explode, transform.position, explode.transform.rotation);
        if (bomb == true)
        {
            GameObject.FindObjectOfType<Gamemanagerscript>().UpdatePoint(-3);
        }
        else
        {
            GameObject.FindObjectOfType<Gamemanagerscript>().UpdatePoint(99999);
        }
        Destroy(gameObject);
    }
    
}