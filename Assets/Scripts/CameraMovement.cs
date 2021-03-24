using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int cameraSpeed = 10;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      float x_pos = transform.position.x;
        float y_pos = transform.position.y;
        float z_pos = transform.position.z;
        if(Input.GetKey(KeyCode.D)){
           transform.position = new Vector3(x_pos + cameraSpeed * Time.deltaTime, y_pos, z_pos); 
        }
    if(Input.GetKey(KeyCode.A)){
           transform.position = new Vector3(x_pos - cameraSpeed * Time.deltaTime, y_pos, z_pos);
        }
        if(Input.GetKey(KeyCode.Space)){
           transform.position = new Vector3(x_pos, y_pos + cameraSpeed * Time.deltaTime, z_pos);
         }
        if(Input.GetKey(KeyCode.LeftShift)){
           transform.position = new Vector3(x_pos, y_pos - cameraSpeed * Time.deltaTime, z_pos);  
        }
        if(Input.GetKey(KeyCode.W)){
           transform.position = new Vector3(x_pos, y_pos, z_pos + cameraSpeed * Time.deltaTime);
         }
        if(Input.GetKey(KeyCode.S)){
           transform.position = new Vector3(x_pos, y_pos, z_pos - cameraSpeed * Time.deltaTime);  
        }
		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene("UniversProcedure");
		}

		if (Input.GetKey(KeyCode.X)){
          yaw += speedH * Input.GetAxis("Mouse X");
          pitch -= speedV * Input.GetAxis("Mouse Y");

          transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
       }
    }



}
