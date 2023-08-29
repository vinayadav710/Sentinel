using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody rb;
    public int bulletStrength = 20;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity=transform.forward*speed;
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        Debug.Log(hitInfo.name);
        enemy Enemy = hitInfo.GetComponent<enemy>();
        if(Enemy != null)
        {
            Enemy.TakeDamage(bulletStrength);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
