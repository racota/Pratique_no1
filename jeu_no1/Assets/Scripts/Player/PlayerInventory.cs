using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    private int coinsCount = 0;

    public int CoinsCount
    {
        get
        {
            return coinsCount;
        }
        set
        {
            coinsCount = value;
        }
    }

    public void addCoins(int qte) {
        coinsCount = coinsCount + qte;
    }

    public void removeCoins(int qte) {
        coinsCount = coinsCount - qte;
    }
}
