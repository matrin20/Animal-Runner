using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementOcean : MonoBehaviour
{

    private float rotAngle;
    private float deltaX;
    private float deltaY;
    private Vector2 mousePosWorldPoint;

    private Quaternion rotationAngle;


    private float yPositionEasing;
    [SerializeField]
    private float easingFactor;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private RunManager _runManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateCharacter();
        MoveCharacterYV2();
    }

    private void RotateCharacter()
    {
        mousePosWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        deltaX = mousePosWorldPoint.x - gameObject.transform.position.x;
        deltaY = mousePosWorldPoint.y - gameObject.transform.position.y;

        rotAngle = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg;
        rotationAngle = Quaternion.Euler(new Vector3(0, 0, rotAngle));
        gameObject.transform.rotation = rotationAngle;

    }

    private void MoveCharacterYV2()
    {
        yPositionEasing = deltaY / easingFactor * movementSpeed * Time.deltaTime;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + yPositionEasing, gameObject.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _runManager.EndRun("Game Over");
    }
}
