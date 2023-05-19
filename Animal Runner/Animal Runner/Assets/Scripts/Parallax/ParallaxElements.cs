using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxElements : MonoBehaviour
{
    [SerializeField]
    private GameObject parallaxLeftPoint;
    [SerializeField]
    private GameObject parallaxRightPoint;
    [SerializeField]
    private float parallaxSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResetParallaxElement();
        ParallaxMovement();
    }

    private void ResetParallaxElement()
    {
        if (gameObject.transform.position.x <= parallaxLeftPoint.transform.position.x)
        {
            gameObject.transform.position = new Vector2(parallaxRightPoint.transform.position.x, gameObject.transform.position.y);
        }
    }

    private void ParallaxMovement()
    {
        float step = parallaxSpeed * Time.deltaTime;

        gameObject.transform.position = new Vector2(gameObject.transform.position.x - step, gameObject.transform.position.y);
    }





}
