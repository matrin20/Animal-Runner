using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulateMissionData : MonoBehaviour
{
    //mission1 fields
    [Header("Mission 1 fields")]
    [SerializeField]
    private TextMeshProUGUI nameField1;
    [SerializeField]
    private TextMeshProUGUI rarityField1;
    [SerializeField]
    private TextMeshProUGUI difficultyField1;
    [SerializeField]
    private TextMeshProUGUI timeField1;
    [SerializeField]
    private Image animalField1;

    //mission2 fields
    [Header("Mission 2 fields")]
    [SerializeField]
    private TextMeshProUGUI nameField2;
    [SerializeField]
    private TextMeshProUGUI rarityField2;
    [SerializeField]
    private TextMeshProUGUI difficultyField2;
    [SerializeField]
    private TextMeshProUGUI timeField2;
    [SerializeField]
    private Image animalField2;

    //mission3 fields
    [Header("Mission 3 fields")]
    [SerializeField]
    private TextMeshProUGUI nameField3;
    [SerializeField]
    private TextMeshProUGUI rarityField3;
    [SerializeField]
    private TextMeshProUGUI difficultyField3;
    [SerializeField]
    private TextMeshProUGUI timeField3;
    [SerializeField]
    private Image animalField3;


    private List<TextMeshProUGUI> names;
    private List<TextMeshProUGUI> rarities;
    private List<TextMeshProUGUI> difficulties;
    private List<TextMeshProUGUI> times;
    private List<Image> animalImages;


    private PlayerData _playerData;

    private int previousMissionCounter;
    private int currentMissionCounter;
    [SerializeField]
    private GenerateMission missionGenerator;
    private List<Mission> _currentMissions;


    [SerializeField]
    private GameObject notification1;
    [SerializeField]
    private GameObject notification2;
    [SerializeField]
    private GameObject notification3;

    private List<GameObject> notificationList;

    private int unseenNotifications;

    [SerializeField]
    private GameObject missionTab;

    [SerializeField]
    private MissionHolder missionHolder1;
    [SerializeField]
    private MissionHolder missionHolder2;
    [SerializeField]
    private MissionHolder missionHolder3;

    private List<MissionHolder> missionHolderList;

    [SerializeField]
    private Sprite defaultSprite;


    [SerializeField]
    private Button missionButton1;
    [SerializeField]
    private Button missionButton2;
    [SerializeField]
    private Button missionButton3;

    private List<Button> missionButtons;


    [SerializeField]
    private Button deleteButton1;
    [SerializeField]
    private Button deleteButton2;
    [SerializeField]
    private Button deleteButton3;

    private List<Button> deleteButtons;

    // Start is called before the first frame update
    void Start()
    {
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();

        currentMissionCounter = _playerData.GetMissions().Count;
        previousMissionCounter = currentMissionCounter;

        names = new List<TextMeshProUGUI>();
        names.Add(nameField1);
        names.Add(nameField2);
        names.Add(nameField3);

        rarities = new List<TextMeshProUGUI>();
        rarities.Add(rarityField1);
        rarities.Add(rarityField2);
        rarities.Add(rarityField3);

        difficulties = new List<TextMeshProUGUI>();
        difficulties.Add(difficultyField1);
        difficulties.Add(difficultyField2);
        difficulties.Add(difficultyField3);

        times = new List<TextMeshProUGUI>();
        times.Add(timeField1);
        times.Add(timeField2);
        times.Add(timeField3);

        animalImages = new List<Image>();
        animalImages.Add(animalField1);
        animalImages.Add(animalField2);
        animalImages.Add(animalField3);

        notificationList = new List<GameObject>();
        notificationList.Add(notification1);
        notificationList.Add(notification2);
        notificationList.Add(notification3);

        missionHolderList = new List<MissionHolder>();
        missionHolderList.Add(missionHolder1);
        missionHolderList.Add(missionHolder2);
        missionHolderList.Add(missionHolder3);

        missionButtons = new List<Button>();
        missionButtons.Add(missionButton1);
        missionButtons.Add(missionButton2);
        missionButtons.Add(missionButton3);

        deleteButtons = new List<Button>();
        deleteButtons.Add(deleteButton1);
        deleteButtons.Add(deleteButton2);
        deleteButtons.Add(deleteButton3);

        if (_playerData.GetUnseenMissionNotifications() > 0)
        {
            notificationList[_playerData.GetUnseenMissionNotifications() - 1].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckForMissionUpdates();
    }

    //perhaps this function shouldn't be in update to maximize efficiency.
    private void CheckForMissionUpdates()
    {
        if (currentMissionCounter != previousMissionCounter)
        {
            previousMissionCounter = currentMissionCounter;
            PopulateMissions();
            if (missionTab.activeInHierarchy == false)
            {
                unseenNotifications++;
                _playerData.SetUnseenMissionNotification(unseenNotifications);
                for (int i =0; i< notificationList.Count; i++)
                {
                    notificationList[i].SetActive(false);
                }
                if (unseenNotifications<=3)
                {
                    notificationList[unseenNotifications - 1].SetActive(true);
                }
            }
        }
    }

    public void IncreaseCurrentNumberOfMissions()
    {
        currentMissionCounter += 1;
    }

    public void DecreaseCurrentNumberOfMissions()
    {
        currentMissionCounter -= 1;
    }

    public int GetNumberOfMissions()
    {
        return currentMissionCounter;
    }

    public void PopulateMissions()
    {
        _currentMissions = _playerData.GetMissions();

        for (int j = 0; j < 3; j++)
        {
            names[j].text = "-";
            rarities[j].text = "-";
            difficulties[j].text = "-";
            times[j].text = "-";
            animalImages[j].sprite = defaultSprite;
            missionHolderList[j].RemoveMyMission();
            missionButtons[j].enabled = false;
            deleteButtons[j].enabled = false;
        }

        if (_currentMissions.Count > 0)
        {
            for (int i = 0; i < _currentMissions.Count; i++)
            {
                names[i].text = _currentMissions[i].GetMissionAnimal().myName;
                rarities[i].text = _currentMissions[i].GetMissionAnimal().myRarity;
                difficulties[i].text = _currentMissions[i].GetDifficultyModifier() + "";
                times[i].text = _currentMissions[i].GetMissionRunTime() + " seconds";
                animalImages[i].sprite = _currentMissions[i].GetMissionAnimal().myGameObject.GetComponent<SpriteRenderer>().sprite;
                missionHolderList[i].SetMyMission(_currentMissions[i]);
                missionButtons[i].enabled = true;
                deleteButtons[i].enabled = true;
            }
        }
    }

    private void OnMouseDown()
    {
        PopulateMissions();
        unseenNotifications = 0;
        _playerData.SetUnseenMissionNotification(0);
        for (int j = 0; j < notificationList.Count; j++)
        {
            notificationList[j].SetActive(false);
        }
    }
}
