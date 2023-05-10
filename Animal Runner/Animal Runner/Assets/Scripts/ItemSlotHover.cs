using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotHover : MonoBehaviour
{
    [SerializeField]
    private GameObject itemPanel;


    private void OnMouseEnter()
    {
        itemPanel.SetActive(true);
    }
}
