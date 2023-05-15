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
    }

    public void ToggleColliders(bool boolean)
    {
        for (int i = 0; i < allColliders.Count; i++)
        {
            allColliders[i].enabled = boolean;
        }
    }

    private void SetObtainedAnimals()
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
}
