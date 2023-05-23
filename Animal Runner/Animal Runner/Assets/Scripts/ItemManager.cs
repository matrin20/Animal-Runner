using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private PlayerData _playerData;

    [SerializeField]
    private List<GameObject> itemLocks;
    [SerializeField]
    private List<GameObject> headSelectionCircles;
    [SerializeField]
    private List<GameObject> flipperSelectionCircles;

    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        RemoveLocks();
        GetHeadSelectionCircle();
        GetFlipperSelectionCircle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RemoveLocks()
    {
        for (int i = 0; i < itemLocks.Count; i++)
        {
            if (_playerData.GetUnlockedLocks(i) == 1)
            {
                itemLocks[i].GetComponent<UnlockItem>().RemoveLock();
            }
        }
    }

    public void GetHeadSelectionCircle()
    {
        for (int i = 0; i < headSelectionCircles.Count; i++)
        {
            headSelectionCircles[i].SetActive(false);
        }
        headSelectionCircles[_playerData.GetHeadSlotItem().itemID].SetActive(true);
    }

    public void GetFlipperSelectionCircle()
    {
        for (int i = 0; i < flipperSelectionCircles.Count; i++)
        {
            flipperSelectionCircles[i].SetActive(false);
        }
        flipperSelectionCircles[_playerData.GetFlipperSlot().itemID - 3].SetActive(true);
    }

}
