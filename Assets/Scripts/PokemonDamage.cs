using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PokemonDamage : MonoBehaviour
{    
    private Vector3 pushBack = new Vector3(0f, 0.5f, 2f);
    public float damage = 25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth healthComponent))
        {
            
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Vector3 velocity_change = pushBack - collision.gameObject.GetComponent<Rigidbody>().velocity;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(velocity_change, ForceMode.VelocityChange);

        }
    }
}
