using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit;


public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    static public float playerHealth = 0f;
    public bool alive = true;
    public GameObject diedScreen = null;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        playerHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0f) // dead
        {
            if(gameObject.TryGetComponent<LocomotionSystem>(out LocomotionSystem locomotionScript))
            {
                gameObject.GetComponent<LocomotionSystem>().enabled = false; // so we can't move
            }
            diedScreen = GameObject.Find("DeadImage");
            diedScreen.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
