using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class getPlayerHealth : MonoBehaviour
{
    // to reference our tmp text
    public TMP_Text Text;

    // Update is called once per frame
    void Update()
    {
        // accessing the players health variable from the PlayerHealth script
        Text.SetText( PlayerHealth.playerHealth.ToString());
    }
}
