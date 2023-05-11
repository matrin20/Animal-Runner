using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUIHoverScale : MonoBehaviour
{
    private float hoverScaleFactor;
    private Vector2 oldScale;

    // Start is called before the first frame update
    void Start()
    {
        hoverScaleFactor = 1.1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScaleButtonUp()
    {
        oldScale = transform.localScale;
        transform.localScale = new Vector2(transform.localScale.x * hoverScaleFactor, transform.localScale.y * hoverScaleFactor);
    }

    public void ScaleButtonDown()
    {
        transform.localScale = oldScale;
    }
}
