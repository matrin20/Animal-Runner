using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInsuffPanel : MonoBehaviour
{

    [SerializeField]
    private GameObject panel;

    private void Start()
    {
        ClosePanel();
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
