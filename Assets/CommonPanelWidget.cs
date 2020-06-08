using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommonPanelWidget : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerMoneyText = null;

    public void SetPlayerMoney(int money)
    {
        playerMoneyText.text = money.ToString();
    }
}
