using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SetNameOnHover : MonoBehaviour
{

    [SerializeField]
    private string myLinkName;
    [SerializeField]
    private TextMeshProUGUI UIHoverText;


    // Start is called before the first frame update
    void Start()
    {
        ResetUIText();
    }

    public void SetUITextOnHover()
    {
        UIHoverText.text = myLinkName;
    }

    public void ResetUIText()
    {
        UIHoverText.text = "";
    }

    private void OnMouseEnter()
    {
        SetUITextOnHover();
    }

    private void OnMouseExit()
    {
        ResetUIText();
    }
}
