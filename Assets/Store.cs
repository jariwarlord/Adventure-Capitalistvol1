using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Store : MonoBehaviour
{
    private System.Random random = new System.Random();
    public float BaseStoreCost { get; set; }
    public int StoreCount { get; private set; }
    public Text StoreCountText;
    public Slider ProgressSlider;
    public GameManager GameManager { get; set; }
    private float StoreTimer;
    private float CurrentTimer;
    private bool StartTimer;
    public float BaseStoreProfit { get; set; }

    private float CalculateFormula(float x)
    {
        float result = (1 + Mathf.Sqrt(5)) / 2 * (Mathf.Sqrt(x)) + Mathf.Sin(x);
        return result;
    }

    private void Start()
    {
        StoreTimer = 12.0f;
        CurrentTimer = 0f;
        StoreCount = 1;
        StartTimer = false;

        ProgressSlider.minValue = 0;
        ProgressSlider.maxValue = StoreTimer;
        ProgressSlider.value = 0f;
    }

    private void Update()
    {
        if (StartTimer)
        {
            CurrentTimer += Time.deltaTime;
            if (CurrentTimer >= StoreTimer)
            {
                Debug.Log("Süre Doldu, Kar Ekleniyor.");
                float profit = CalculateFormula(BaseStoreCost);
                GameManager.AddToBalance(profit * StoreCount);

                StartTimer = false;
                CurrentTimer = 0f;
            }
        }

        ProgressSlider.value = CurrentTimer;
    }

    public void BuyStoreOnClick()
    {
        if (!GameManager.CanBuy(BaseStoreCost))
        {
            Debug.Log("Yetersiz Bakiye!");
            return;
        }

        GameManager.AddToBalance(-BaseStoreCost);

        float fluctuation = random.Next(-10, 10) / 100f;
        float totalCost = BaseStoreCost + fluctuation;
        float profit = CalculateFormula(totalCost);

      

        StoreCount++;
        StoreCountText.text = StoreCount.ToString();
    }

    public void StoreOnClick()
    {
        Debug.Log("Süre baþladý!");
        if (!StartTimer)
        {
            StartTimer = true;
        }
    }
}
