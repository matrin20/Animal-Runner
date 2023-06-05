using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInfoPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject infoPanel;

    // Start is called before the first frame update
    void Start()
    {
        OnInfoExit();
    }

    public void OnInfoEnter()
    {
        infoPanel.SetActive(true);
    }

    public void OnInfoExit()
    {
        infoPanel.SetActive(false);
    }

}
