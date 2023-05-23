using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HabitatInfoManager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI levelField;
    [SerializeField]
    private TextMeshProUGUI collectedField;
    [SerializeField]
    private TextMeshProUGUI costField;

    private PlayerData _playerData;

    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();

        FillHabitatInfoFields();
    }


    public void FillHabitatInfoFields()
    {
        levelField.text = "Habitat level: " + _playerData.GetHabitatLevel();
        collectedField.text = "Animals collected: " + _playerData.GetAnimals().Count + " / " + _playerData.GetAllAnimals().Count;
    }

    

}
