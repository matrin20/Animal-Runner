using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelectItem : MonoBehaviour
{

    [SerializeField]
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetSceneName()
    {
        return sceneName;
    }

    public void SetSceneName(string newName)
    {
        sceneName = newName;
    }
}
