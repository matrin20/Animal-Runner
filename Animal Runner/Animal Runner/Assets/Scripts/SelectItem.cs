using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> headSelectionCircles;
    [SerializeField]
    private int circleIndex;
    [SerializeField]
    private Item item;
    private PlayerData _playerData;
    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        for (int i = 0; i < headSelectionCircles.Count; i++)
        {
            headSelectionCircles[i].SetActive(false);
        }
        headSelectionCircles[circleIndex].SetActive(true);
        _playerData.SetHeadSlotItem(item);
    }


}
