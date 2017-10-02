using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    [SerializeField]
    private GameObject coinsCountDisplay;
    [SerializeField]
    private PlayerInventory playerInventory;

    private void Update()
    {
        updateCoinsDisplay();
    }

    public void updateCoinsDisplay()
    {
        //GameObject coinsCountDisplay = GameObject.Find("CoinsCountDisplay");
        coinsCountDisplay.GetComponentInChildren<Text>().text = playerInventory.CoinsCount.ToString();
    }
}
