using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OpenLogBook : MonoBehaviour
{
    [SerializeField]
    private GameObject logBook;
    private PlayerData _playerData;
    [SerializeField]
    private List<TextMeshProUGUI> epipelagicAnimalCounts;
    [SerializeField]
    private List<Image> logBookAnimalImages;

    [SerializeField]
    private List<Collider2D> allColliders;

    [SerializeField]
    private GameObject missionTab;

    // Start is called before the first frame update
    void Start()
    {
        logBook.SetActive(false);
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        SetObtainedAnimals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        logBook.SetActive(true);
        ToggleColliders(false);
        CloseOtherTabs();
    }

    public void ToggleColliders(bool boolean)
    {
        for (int i = 0; i < allColliders.Count; i++)
        {
            allColliders[i].enabled = boolean;
        }
    }

    //this function will only work properly once all animals are implemented. This also means the IDs of the animal need to be changed to match their new order once implemented.
    public void SetObtainedAnimals()
    {
        //access playerdata and retrieve the number of each specific animal that has been caught.
        //list of the icons belonging to each tier
        //if [i] of an icon list has been inlocked (checked vs. index perhaps), unhide the questionmark on top or put the .sprite of the image component as the animal.gameobject.sprite
        //list of .text components in the lower corners of the image that are set to the number of catches.

        for (int i=0; i< epipelagicAnimalCounts.Count; i++)
        {
            if (_playerData.GetAnimalCount(i + 1) > 0)
            {
                logBookAnimalImages[i].sprite = _playerData.GetAllAnimals()[i].myGameObject.GetComponent<SpriteRenderer>().sprite;
            }
            epipelagicAnimalCounts[i].text = _playerData.GetAnimalCount(i + 1) + "";
        }

    }

    private void CloseOtherTabs()
    {
        if (missionTab.activeInHierarchy == true)
        {
            missionTab.SetActive(false);
        }
    }
}
