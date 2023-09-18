using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;


public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float playerHealth = 0f;
    public bool alive = true;
    public GameObject diedScreen = null;
    public TMP_Text Text;// to reference our tmp text for UI to show health
    public LocomotionProvider locomotion_provider = null;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        playerHealth = maxHealth;
        Text.SetText(playerHealth.ToString());
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        Text.SetText(playerHealth.ToString());

        if (playerHealth <= 0f) // dead
        {
            locomotion_provider.enabled = false;
            diedScreen.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
