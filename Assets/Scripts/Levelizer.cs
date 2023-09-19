using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using System.Threading;
using System.Runtime.CompilerServices;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class Levelizer : MonoBehaviour
{
    
    [Tooltip("The enemy that will be spawned")]
    public GameObject originalObject = null;
    [Tooltip("Where the enemy will start spawning from")] //we use 3 so we can make them spawn away from the user so they dont spawn on top of the user
    public Transform spawnPoint1 = null;
    public Transform spawnPoint2 = null;
    public Transform spawnPoint3 = null;
    [Tooltip("The XR Rig")]
    public XROrigin xRRig = null;

    static public int numEnemies =5;
    static public int level;
 
    // Start is called before the first frame update
    void Start()
    {
        numEnemies = 5;
        level = 0;
        StartLevel();
    }

    public void StartLevel()
    {
        Transform spawnPoint = GetFurthestSpawnPoint();

        for(int i = 0; i < numEnemies; i++) // spawning enemies
        {
            int x_offset_multiplier = Random.Range(2, 4);
            int z_offset = Random.Range(-5, 20);
            // it starts at the spawn point we made, this offset helps randomize where enemies spawn
            Vector3 offset = new Vector3(x_offset_multiplier*i,0,z_offset);
            GameObject newObject = Instantiate(originalObject,spawnPoint.position + offset,spawnPoint.rotation, this.transform);
            newObject.GetComponent<PokemonMovement>().target = xRRig.gameObject.transform;  // initializing xrrig as target for pokemon to go to
            
        }
    }

    // finding the spawn point furthest from the user
    public Transform GetFurthestSpawnPoint()
    {
        float dist1 = Vector3.Distance(spawnPoint1.position, xRRig.transform.position);
        float dist2 = Vector3.Distance(spawnPoint2.position, xRRig.transform.position);
        float dist3 = Vector3.Distance(spawnPoint3.position, xRRig.transform.position);

        if(dist1 > dist2 && dist1 > dist3) // if distance from spawn point one is greatest
        {
            return spawnPoint1;
        } else if (dist2 > dist3 && dist2 > dist1) // if distance from spawn point two is greatest
        { 
            return spawnPoint2;
        } else if (dist3 > dist1 && dist3 > dist2) // if distance from spawn point 3 is greatest
        {
            return spawnPoint3;
        } else // just in case something happens that shouldnt
        {
            return spawnPoint1;
        }
    }

    public void LevelUp()
    {
        level++;
        PokemonHealth.max_health += 25f;
        numEnemies = level * 2;
        StartLevel();
    }


    // Update is called once per frame
    void Update()
    {
        if (numEnemies == 0)
        {
            LevelUp();
        }
    }
}
