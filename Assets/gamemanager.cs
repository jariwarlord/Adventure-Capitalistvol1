using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public GameObject storeObject1;
    public GameObject storeObject2;
    public GameObject storeObject3;
    public GameObject storeObject4;

    private Store store1;
    private Store store2;
    private Store store3;
    private Store store4;
    public Text CurrentBalanceText;
    public float CurrentBalance;
    // Start is called before the first frame update
    void Start()
    {
        CurrentBalance = 20.0f;    
        CurrentBalanceText.text = CurrentBalance.ToString("C2");

        store1 = storeObject1.GetComponent<Store>();
        store1.BaseStoreCost = 3.50f;
        store1.BaseStoreProfit = 1.0f; 
        store2 = storeObject2.GetComponent<Store>();
        store2.BaseStoreCost = 5.50f;
        store2.BaseStoreProfit = 2.0f;
        store3 = storeObject3.GetComponent<Store>();
        store3.BaseStoreCost = 2.50f;
        store3.BaseStoreProfit = 1.2f;
        store4 = storeObject4.GetComponent<Store>();
        store4.BaseStoreCost = 1.50f;
        store4.BaseStoreProfit = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToBalance(float amt)
    {
        CurrentBalance += amt;
        CurrentBalanceText.text = CurrentBalance.ToString("C2");
    }
    public bool CanBuy(float AmtToSpend)
    {
        if (CurrentBalance < AmtToSpend)
            return false;
        else
            return true;
    }


}
