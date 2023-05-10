using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockItem : MonoBehaviour
{
    [SerializeField]
    private GameObject slotToUnlock;
    [SerializeField]
    private Item itemToUnlock;
    private PlayerData _playerData;
    private int currency;
    [SerializeField]
    private TextMeshProUGUI costField;

    private void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        costField.text = "Cost: " + itemToUnlock.itemPrice;
    }

    private void OnMouseDown()
    {
        currency = _playerData.GetCurrency();
        if (currency > itemToUnlock.itemPrice)
        {
            slotToUnlock.SetActive(true);
            gameObject.SetActive(false);
            costField.gameObject.SetActive(false);
        } else
        {
            Debug.Log("You don't have enough currency!");
        }
    }
}
