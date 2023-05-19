using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUIHoverWhite : MonoBehaviour
{

    [SerializeField]
    private GameObject selectionGO;
    
    // Start is called before the first frame update
    void Start()
    {
        selectionGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        selectionGO.SetActive(true);
    }

    private void OnMouseExit()
    {
        selectionGO.SetActive(false);
    }
}
