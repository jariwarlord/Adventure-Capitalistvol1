using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public Text CurrentBalanceText;
    public float CurrentBalance;
    // Start is called before the first frame update
    void Start()
    {
        CurrentBalance = 6.0f;    
        CurrentBalanceText.text = CurrentBalance.ToString("C2");
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
