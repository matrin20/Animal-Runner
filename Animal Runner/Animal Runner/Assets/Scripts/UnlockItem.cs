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
    [SerializeField]
    private GameObject costIcon;
    [SerializeField]
    private GameObject insuffPanel;

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
            _playerData.ChangeCurrency(itemToUnlock.itemPrice * -1);
            RemoveLock();
            _playerData.SetUnlockedLocks(myIndex);
        }
        else
        {
            Debug.Log("You don't have enough currency!");
            insuffPanel.SetActive(true);
        }

        GameObject.Find("Currency").GetComponent<DisplayCurrency>().SetDisplayCurrency();
    }

    public void RemoveLock()
    {
        slotToUnlock.SetActive(true);
        costField.gameObject.SetActive(false);
        gameObject.SetActive(false);
        costIcon.SetActive(false);
    }
}
