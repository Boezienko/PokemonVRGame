using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class PokemonHealth : MonoBehaviour
{
    static public float max_health = 100f;
    public float cur_health = 0f;
    public bool alive = true;
    //private GameObject _levelizer = null;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        cur_health = max_health;
    }

    public void TakeDamage(float damage)
    {
        cur_health -= damage;

        if (cur_health <= 0f) // killing blow
        {
            Levelizer.numEnemies--;
            alive = false;
            gameObject.SetActive(false); // making it die
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
