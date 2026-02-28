using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 200;
    private GameObject focalpoint;
    public bool hasPower = false;
    public float pushPower = 50;
    [Range(2, 10)]
    public float powerDuration = 10;
    public float flickerDuration = 5;
    public GameObject powerUpIndicator;
    private float initialPowerTime = 0f;
    public float outTime = 3;
    public GameObject deathpanel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalpoint = GameObject.Find("Focal point");

    }

   
    private void FixedUpdate()
    {
        float inputy = Input.GetAxis("Vertical");
        rb.AddForce(focalpoint.transform.forward * (inputy * force * Time.deltaTime));
        powerUpIndicator.transform.position = transform.position;
        if (hasPower == true &&((powerDuration - (Time.time - initialPowerTime)) < outTime))
        {
            Debug.Log("Running out!");
        }
        if (transform.position.y < -1)
        {
            Destroy(gameObject);
            deathpanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Power"))
        {
            hasPower = true;
            Destroy(other.gameObject);
            StartCoroutine(Cooldown());
            powerUpIndicator.SetActive(true);
            initialPowerTime = Time.time;

            
            
            
        }
    
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Enemy") && hasPower == true)
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 pos = transform.position;
            Vector3 enemypos = other.transform.position;
            Vector3 dir = enemypos - pos ;
            enemyRb.AddForce(dir.normalized * pushPower, ForceMode.Impulse);
            
        }
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(powerDuration);
        hasPower = false;
        powerUpIndicator.SetActive(false);


    }
}
