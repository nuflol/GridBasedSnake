using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenWarp : MonoBehaviour
{
    private float leftConstraint = Screen.width;
    private float rightConstraint = Screen.width;
    private float bottomConstraint = Screen.height;
    private float topConstraint = Screen.height;
    private float offset = 1f;
    private Camera mainCamera;
    private float distanceZ;
    void Start()
    {
        mainCamera = Camera.main;
        distanceZ = Mathf.Abs(mainCamera.transform.position.z + transform.position.z);
        leftConstraint = mainCamera.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        bottomConstraint = mainCamera.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topConstraint = mainCamera.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;

    }

   
    void FixedUpdate()
    {
        if (transform.position.x < leftConstraint - offset)
        {
            transform.position = new Vector3(rightConstraint - 0.10f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rightConstraint)
        {
            transform.position = new Vector3(leftConstraint, transform.position.y, transform.position.z);
        }
        if (transform.position.y < bottomConstraint - offset)
        {
            transform.position = new Vector3(transform.position.x, topConstraint + offset, transform.position.z);
        }
        if (transform.position.y > topConstraint + offset)
        {
            transform.position = new Vector3(transform.position.x, bottomConstraint - offset, transform.position.z);
        }
    }
}
