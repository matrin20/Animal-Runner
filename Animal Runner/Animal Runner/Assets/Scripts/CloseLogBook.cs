using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseLogBook : MonoBehaviour
{
    [SerializeField]
    private GameObject logBook;

    public void CloseBook()
    {
        logBook.SetActive(false);
    }
}
