using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    public float damage = 25f;

    [Tooltip("The object that will be spawned")]
    public GameObject originalObject = null;
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
        if(collision.gameObject.TryGetComponent<PokemonHealth>(out PokemonHealth healthComponent)) // checking to see if we are colliding with an object that has the PokemonHealth script
        {
            collision.gameObject.GetComponent<PokemonHealth>().TakeDamage(damage);
        }

        GameObject newObject = Instantiate(originalObject, collision.contacts[0].otherCollider.transform);
        newObject.GetComponent<Rigidbody>().useGravity = false;
        
        Destroy(gameObject);
    }
}
