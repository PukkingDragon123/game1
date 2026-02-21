using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraController : MonoBehaviour
{

    public float rotspeed = 50f;

    private void Start()
    {
        int i = 0;
        while (i < 10) 
        {
            Debug.Log(i);
            i++;
        }
    }



    // Update is called once per frame
    void Update()
    {

        
        float input = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, input * rotspeed * Time.deltaTime);

    }
}
