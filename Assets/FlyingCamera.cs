using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCamera : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = this.transform.position;
        newPos.z += Input.GetAxis("Vertical") * Time.deltaTime * speed;
        newPos.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        this.transform.position = newPos;
    }
}
