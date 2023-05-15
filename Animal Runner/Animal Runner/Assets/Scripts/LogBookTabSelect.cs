using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBookTabSelect : MonoBehaviour
{
    [SerializeField]
    private List<Canvas> allTabs;
    
    public static GameObject selectedTab;

    [SerializeField]
    private GameObject myTab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchTabs()
    {
        selectedTab = myTab;

        for (int i = 0; i < allTabs.Count; i++)
        {
            allTabs[i].sortingOrder = 0;
        }

        selectedTab.GetComponent<Canvas>().sortingOrder = 2;
    }

}
