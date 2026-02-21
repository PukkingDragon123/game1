using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemymovement : MonoBehaviour
{
    
    public float force = 150;
    private Rigidbody rb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 playerpos = player.transform.position;
        Vector3 dir = playerpos - pos;
        rb.AddForce(dir.normalized * force * Time.deltaTime);
        if (transform.position.y < -1)
        {
            GameObject.Find("GameObject").GetComponent<Spawner>().countEnemy();
            Destroy(gameObject);
        }
       
        
    }
}
