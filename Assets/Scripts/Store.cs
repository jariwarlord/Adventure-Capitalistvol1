using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class store : MonoBehaviour {

    int StoreCount;
    // Start is called before the first frame update
    void Start()
    {
        StoreCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyStoreOnClick()
    {
        StoreCount++;
        Debug.Log(StoreCount);
    }
}
