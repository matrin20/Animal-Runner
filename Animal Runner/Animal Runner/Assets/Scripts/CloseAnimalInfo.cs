using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAnimalInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject animalInfo;


    public void CloseAnimalInfoPanel()
    {
        animalInfo.SetActive(false);
    }
}
