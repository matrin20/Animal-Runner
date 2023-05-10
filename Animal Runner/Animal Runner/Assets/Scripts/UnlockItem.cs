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
    [SerializeField]
    private int myIndex;

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
            RemoveLock();
            _playerData.SetUnlockedLocks(myIndex);
        }
        else
        {
            Debug.Log("You don't have enough currency!");
        }
    }

    public void RemoveLock()
    {
        slotToUnlock.SetActive(true);
        costField.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
