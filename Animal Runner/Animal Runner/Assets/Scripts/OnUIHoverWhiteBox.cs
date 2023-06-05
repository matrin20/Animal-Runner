using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUIHoverWhiteBox : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> selectBoxes;

    [SerializeField]
    private GameObject mySelectBox;

    public void OnUIEnter()
    {
        OnUIExit();

        mySelectBox.SetActive(true);
    }

    public void OnUIExit()
    {
        for (int i = 0; i < selectBoxes.Count; i++)
        {
            selectBoxes[i].SetActive(false);
        }
    }
}
