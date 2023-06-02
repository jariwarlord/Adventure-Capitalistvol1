using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
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
    private float currentBalance;

    private void Start()
    {
        currentBalance = 20.0f;
        CurrentBalanceText.text = currentBalance.ToString("C2");

        store1 = storeObject1.GetComponent<Store>();
        store1.BaseStoreCost = 3.50f;
        store1.BaseStoreProfit = 1.0f;
        store1.GameManager = this;

        store2 = storeObject2.GetComponent<Store>();
        store2.BaseStoreCost = 5.50f;
        store2.BaseStoreProfit = 2.0f;
        store2.GameManager = this;

        store3 = storeObject3.GetComponent<Store>();
        store3.BaseStoreCost = 2.50f;
        store3.BaseStoreProfit = 1.2f;
        store3.GameManager = this;

        store4 = storeObject4.GetComponent<Store>();
        store4.BaseStoreCost = 1.50f;
        store4.BaseStoreProfit = 1.5f;
        store4.GameManager = this;
    }

    public void AddToBalance(float amount)
    {
        currentBalance += amount;
        CurrentBalanceText.text = currentBalance.ToString("C2");
    }

    public bool CanBuy(float amount)
    {
        return currentBalance >= amount;
    }
}
