using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> selectionCircles;
    [SerializeField]
    private int circleIndex;
    [SerializeField]
    private Item item;
    private PlayerData _playerData;
    // Start is called before the first frame update
    private EquippedCharacterManager EquippedCharacterManager;

    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        EquippedCharacterManager = GameObject.Find("EquippedCharacterManager").GetComponent<EquippedCharacterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        SetItem();

        EquippedCharacterManager.OnBreatherSelect();
        EquippedCharacterManager.OnFlipperSelect();
    }


    private void SetItem()
    {
        for (int i = 0; i < selectionCircles.Count; i++)
        {
            selectionCircles[i].SetActive(false);
        }
        selectionCircles[circleIndex].SetActive(true);


        if (item.itemSlot == "Head")
        {
            //set head slot
            _playerData.SetHeadSlotItem(item);
        }
        else if (item.itemSlot == "Feet")
        {
            //set feet slot
            _playerData.SetFlipperSlot(item);

        } else if (item.itemSlot == "Body")
        {
            //set body slot


        }
    }


}
