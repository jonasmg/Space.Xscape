using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
//using System.Diagnostics;
//using UnityEngine.CoreModule;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mouse screen pos
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 screenPosition3D = new Vector3(Input.mousePosition.x - (Screen.width/ 2), Input.mousePosition.y - (Screen.height/2), 0);
        //mouse world pos
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        //depth and position. position is the players position plus the screen position of the mouse minus half the screen
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.y * (0.1f) - 1);
        //pickaxe rotation

        //angle which pickaxe should be. Is calculated from player to mouse angle
        Vector3 direction = player.transform.position - screenPosition3D;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180;

        
        if (angle > 90 && angle < 270) {
            angle -= 30;
        }
        else angle += 30;

        //Debug.Log("pickaxe angle: " + angle);

        Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);

        //Debug.DrawRay(transform.position, direction, Color.green);

        //sets angle of pickaxe
        transform.eulerAngles = Vector3.forward * angle;

        // Rotate the cube by converting the angles into a quaternion.
        //transform.rotation = Quaternion.Rotation(angle);
    }
}