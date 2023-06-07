using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayCurrency : MonoBehaviour
{
    private PlayerData _playerData;
    [SerializeField]
    private TextMeshProUGUI currencyField;


    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();

        SetDisplayCurrency();
    }


    public void SetDisplayCurrency()
    {
        currencyField.text = _playerData.GetCurrency() + "";
    }

}
