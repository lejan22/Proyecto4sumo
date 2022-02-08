using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucle : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    
    public int initialNum = 10;
    public Vector3[] positions;
    // Start is called before the first frame update
    void Start()
    {
      /*  for (int i = initialNum; i >= 0; i -= 1)
        {
            Debug.Log(i);
        }
      */
        for (int i = 0; i < positions.Length; i++)
        {
            Instantiate(enemyPrefabs[i], positions[i], enemyPrefabs[i].transform.rotation);
        }
        foreach (Vector3 pos in positions)
        {
            Instantiate(enemyPrefabs[0], pos, enemyPrefabs[0].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
  
}
