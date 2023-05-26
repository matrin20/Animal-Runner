using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCharacterEquips : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> flippers;
    [SerializeField]
    private List<GameObject> breathers;
    private GameObject activeFlipper;
    private GameObject activeBreather;

    private PlayerData _playerData;

    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        SetEquipsActive();
    }



    private void SetEquipsActive()
    {
        int flipperIndex = 0;
        if (_playerData.GetFlipperSlot().itemID > 0)
        {
            flipperIndex = _playerData.GetFlipperSlot().itemID - 3;
        }
        activeFlipper = flippers[flipperIndex];

        activeBreather = breathers[_playerData.GetHeadSlotItem().itemID];

        activeFlipper.SetActive(true);
        activeBreather.SetActive(true);
    }

}
