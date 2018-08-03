using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_CoinManager : ScriptableObject {

    public int numOfCoins;

    public void AddCoins(int num)
    {
        numOfCoins += num;
        Debug.Log("you now have " + numOfCoins + " coins");
    }

    public void RemoveCoins(int num)
    {
        numOfCoins -= num;
        Debug.Log("COINS REMOVED: you now have " + numOfCoins + " coins");
    }

}
