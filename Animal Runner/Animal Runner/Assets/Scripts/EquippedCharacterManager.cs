using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedCharacterManager : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> flippers;
    private GameObject currentFlipper;


    [SerializeField]
    private List<GameObject> breathers;
    private GameObject currentBreather;

    private PlayerData _playerData;


    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();

        //if (_playerData.GetFlipperSlot().itemID - 3 > 0)
        //{
        //    currentFlipper = flippers[_playerData.GetFlipperSlot().itemID - 3];
        //} else
        //{
        //    currentFlipper = flippers[0];
        //}
        //currentFlipper.SetActive(true);

        OnFlipperSelect();
        OnBreatherSelect();
    }



    public void OnFlipperSelect()
    {
        if (currentFlipper != null)
        {
            currentFlipper.SetActive(false);
        }

        int flipperIndex = 0;

        if (_playerData.GetFlipperSlot().itemID - 3 > 0)
        {
            flipperIndex = _playerData.GetFlipperSlot().itemID - 3;
        }

        currentFlipper = flippers[flipperIndex];
        currentFlipper.SetActive(true);
    }

    public void OnBreatherSelect()
    {
        if (currentBreather != null)
        {
            currentBreather.SetActive(false);
        }

        currentBreather = breathers[_playerData.GetHeadSlotItem().itemID];
        currentBreather.SetActive(true);
    }



}
