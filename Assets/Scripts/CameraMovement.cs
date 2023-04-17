using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public bool clicked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
            
        }
        if (clicked)
        {

            transform.eulerAngles += rotationSpeed * new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0);
            Debug.Log("rotate");
        }
        if (Input.GetMouseButtonUp(0))
        {
            clicked=false;
        }
        
    }
}
