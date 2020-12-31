using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text _coinsLabel;

    private void Start()
    {
        // Set coins to zero at startup
        UpdateCoinDisplay(0);
    }

    /// <summary>
    /// Update coins displayed on the screen
    /// </summary>
    /// <param name="coinsCount"></param>
    public void UpdateCoinDisplay(int coinsCount)
    {
        _coinsLabel.text = $"Coins:{coinsCount}";
    }

}
