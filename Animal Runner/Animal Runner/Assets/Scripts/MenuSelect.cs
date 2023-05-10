using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    private string selectOption;

    private void OnMouseDown()
    {
        SceneLoader();
    }

    void SceneLoader()
    {
        selectOption = gameObject.GetComponent<MenuSelectItem>().GetSceneName();
        SceneManager.LoadScene(selectOption);
    }
}



