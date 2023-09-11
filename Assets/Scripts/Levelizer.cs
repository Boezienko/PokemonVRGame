using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using System.Threading;
using System.Runtime.CompilerServices;

public class Levelizer : MonoBehaviour
{
    
    [Tooltip("The enemy that will be spawned")]
    public GameObject originalObject = null;
    [Tooltip("Where the enemy will start spawning from")]
    public Transform spawnPoint = null;

    static public int numEnemies;
    private int level;



    // Start is called before the first frame update
    void Start()
    {
        numEnemies = 0;
        level = 0;
        StartLevel(level);
    }

    public void StartLevel(int _level)
    {
        for(int i = 0; i < numEnemies; i++) // spawning enemies
        {
            Vector3 offset = new Vector3(2*i,0,0);
            GameObject newObject = Instantiate(originalObject, spawnPoint.position + offset,spawnPoint.rotation);            
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (numEnemies == 0)
        {
            level++;
            PokemonHealth.max_health += 25f;
            numEnemies = level * 2;
            StartLevel(level);
        }
    }
}
