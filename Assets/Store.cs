using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {

    float CurrentBalance;
    public float BaseStoreCost { get; set; }
    int StoreCount;
    public Text StoreCountText;
    public Slider ProgressSlider;
    public gamemanager GameManager;
    float StoreTimer;
    float CurrentTimer;
    bool StartTimer;
    public float BaseStoreProfit { get; set; }
    // Start is called before the first frame update
    public Store(float baseCost, float baseProfit)
    {
        BaseStoreCost = baseCost;
        BaseStoreProfit = baseProfit;
    }
    void Start()
    {
        StoreTimer = 5.0f;
        CurrentTimer = 0;
        StoreCount = 1; 
        //BaseStoreCost = 1.50f;
        StartTimer = false;
        //BaseStoreProfit = .50f;
        ProgressSlider.minValue = 0;
        ProgressSlider.maxValue = StoreTimer;
        ProgressSlider.value = CurrentTimer;
    }


    // Update is called once per frame
    void Update()
    {
        if (StartTimer)
        {
            CurrentTimer += Time.deltaTime;
            if(CurrentTimer > StoreTimer)
            {
                Debug.Log("Timer has ended. Reset.");
                StartTimer = false;
                CurrentTimer = 0f;
                GameManager.AddToBalance(BaseStoreProfit * StoreCount);
            }
            
        }
        ProgressSlider.value = CurrentTimer;

    }
    public void BuyStoreOnClick()
    {
        if (!GameManager.CanBuy(BaseStoreCost))
            return;
        StoreCount = StoreCount + 1;
        Debug.Log(StoreCount);
        StoreCountText.text = StoreCount.ToString();
        GameManager.AddToBalance(-BaseStoreCost);
        
        
    }
    public void StoreOnClick()  
    {
        Debug.Log("Timer Has Started");
        if (!StartTimer)
           StartTimer = true;
            
        
        
    }

}
