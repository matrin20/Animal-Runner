using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLogBook : MonoBehaviour
{
    [SerializeField]
    private GameObject logBook;
    // Start is called before the first frame update
    void Start()
    {
        logBook.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        logBook.SetActive(true);
    }
}
