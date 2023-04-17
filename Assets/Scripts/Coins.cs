using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject[] coinArray;
    // Start is called before the first frame update
    void Start()
    {
        Coin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Coin()
    {
        for (int i = 0; i < coinArray.Length; i++)
        {
            GameObject coin = Instantiate(coinPrefab, coinArray[i].gameObject.transform.position, Quaternion.identity);

        }

    }
    
}
