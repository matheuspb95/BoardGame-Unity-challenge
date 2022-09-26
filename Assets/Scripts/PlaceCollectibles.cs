using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCollectibles : MonoBehaviour
{
    public GameObject collectiblePrefab;
    [Range(0.0f, 1.0f)]
    public float spawnChance;
    public int spawnLimit = 4;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            if((child.localPosition.x + child.localPosition.y >= spawnLimit) && 
               (child.localPosition.x + child.localPosition.y <= 31 - spawnLimit)){
                if(Random.Range(0f, 1f) < spawnChance){
                    Instantiate(collectiblePrefab, child);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
