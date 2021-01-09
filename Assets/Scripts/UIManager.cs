using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text _coinsLabel;

    [SerializeField]
    Text _livesLabel;

    private void Start()
    {
        // Set coins to zero at startup
        UpdateCoinDisplay(0);
    }

    /// <summary>
    /// Update Players coins displayed on the screen
    /// </summary>
    /// <param name="coinsCount"></param>
    public void UpdateCoinDisplay(int coinsCount)
    {
        _coinsLabel.text = $"Coins:{coinsCount}";
    }

    /// <summary>
    /// Update Player lives count diplayed on the screen
    /// </summary>
    /// <param name="livesCount"></param>
    public void UpdateLivesDisplay(int livesCount)
    {
        _livesLabel.text = $"Lives:{livesCount}";
    }

}
