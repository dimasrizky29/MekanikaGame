using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject[] coinSpawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoin", 5, 4 );
    }

    // Update is called once per frame

    Vector3 getRandomPos()
    {
        float x = Random.Range(-1, 1);
        float y = 0.03f;
        float z = Random.Range(-15, 5);

        Vector3 newPos = new Vector3(x, y, z);
        return newPos;
    }
    void SpawnCoin()
    {
        Instantiate(coinSpawn[Random.Range(0,9)], getRandomPos(), Quaternion.identity);
    }
}
