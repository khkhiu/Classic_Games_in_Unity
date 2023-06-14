using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow)){
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow)){
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow)){
            _direction = Vector2.right;
        }
    }

    private void FixedUpdate() 
    {
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }
}
