using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCamera : MonoBehaviour
{
    public float speed = 5;
    public float lookSensitivity = 1;
    private bool mouseLock = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = this.transform.position;
        newPos += transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed;
        newPos += transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        newPos.y = this.transform.position.y;
        this.transform.position = newPos;

        Vector2 mouseDelta = lookSensitivity * new Vector2( Input.GetAxis( "Mouse X" ), -Input.GetAxis( "Mouse Y" ) );
        Quaternion rotation = transform.rotation;
		Quaternion horiz = Quaternion.AngleAxis( mouseDelta.x, Vector3.up );
		Quaternion vert = Quaternion.AngleAxis( mouseDelta.y, Vector3.right );
		transform.rotation = horiz * rotation * vert;

        if (Input.GetMouseButtonDown(0))
        {
            if (mouseLock)
            {
                Cursor.lockState = CursorLockMode.None;
                mouseLock = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                mouseLock = true;
            }

        }
    }
}
