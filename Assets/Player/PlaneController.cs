using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    GameObject currentPlane;
    Rigidbody2D planeRigidbody;

    bool engineStarted = false;
    bool throttleIsUp = false;

    float speed;
    [SerializeField] float maxSpeed;
    private float planeXValue;
    private float planeYValue;

    // Start is called before the first frame update
    void Start()
    {
        currentPlane = gameObject;
        Rigidbody2D planeRigidbody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        planeXValue = gameObject.transform.position.x;
        planeYValue = gameObject.transform.position.y;
    }

    void Update()
    {
        planeXValue += speed;
        if (throttleIsUp == true)
        {
            while (speed < maxSpeed)
            {
                speed += 1f;
            }
            gameObject.transform.position = new Vector2(planeXValue, planeYValue);
        }
        if (throttleIsUp == false)
        {
            while (speed > 0)
            {
                speed -= 1;
            }
        }

        Throttle();
    }

    void Throttle()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            engineStarted = true;
            Debug.Log("Engine started");
        }
        if (engineStarted == true)
        {
            if (Input.GetAxis("Mouse ScrollWheel")> 0f)
            {
                Debug.Log("Throttle up");
                throttleIsUp = true;
            }
            if (Input.GetAxis("Mouse ScrollWheel")< 0f)
            {
                Debug.Log("Throttle Down");
                throttleIsUp = false;
            }
        }
    }
}
