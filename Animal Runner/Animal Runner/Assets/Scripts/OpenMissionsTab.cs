using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMissionsTab : MonoBehaviour
{
    [SerializeField]
    private GameObject missionsTab;
    [SerializeField]
    private List<Collider2D> collidersToDisable;
    
    // Start is called before the first frame update
    void Start()
    {
        missionsTab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (missionsTab.activeInHierarchy == true)
        {
            CloseMissionsTab();
            ToggleColliders(true);
        } else
        {
            missionsTab.SetActive(true);
            ToggleColliders(false);
        }
    }

    public void CloseMissionsTab()
    {
        missionsTab.SetActive(false);
    }

    public void ToggleColliders(bool boolean)
    {
        for (int i = 0; i < collidersToDisable.Count; i++)
        {
            collidersToDisable[i].enabled = boolean;
        }
    }
}
