using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanelHover : MonoBehaviour
{

    private void OnMouseExit()
    {
        gameObject.SetActive(false);
    }
}
