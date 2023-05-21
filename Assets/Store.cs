using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {

    float CurrentBalance;
    float BaseStoreCost;
    int StoreCount;
    public Text StoreCountText;
    public Slider ProgressSlider;
    public gamemanager GameManager;
    float StoreTimer;
    float CurrentTimer;
    bool StartTimer;
    float BaseStoreProfit;
    // Start is called before the first frame update
    void Start()
    {
        StoreTimer = 6.0f;
        CurrentTimer = 0;
        StoreCount = 1; 
        BaseStoreCost = 1.50f;
        StartTimer = false;
        BaseStoreProfit = .50f;
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
        ProgressSlider.value = CurrentTimer / StoreTimer;

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
