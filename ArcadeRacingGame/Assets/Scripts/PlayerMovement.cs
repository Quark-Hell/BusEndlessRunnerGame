using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    public Transform carCollider;
    
    public float rotationSpeed = 50;

    void FixedUpdate()
    {
        //carCollider.position = transform.position;

        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;

        // rotate while moving
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            //Set a rate at which we should turn
            float turnSpeed = rotationSpeed * Time.deltaTime;
            //Connect turning rate to horizonal motion for smooth transition
            float rotate = Input.GetAxis("Horizontal") * turnSpeed;
            //            //Get current rotation
            float currentRotation = gameObject.transform.rotation.z;
            //            //Add current rotation to rotation rate to get new rotation
            Quaternion rotation = Quaternion.Euler(0, 0, currentRotation + rotate);
            //            //Move object to new rotation
            gameObject.transform.rotation = rotation;
            gameObject.transform.Rotate(Vector3.forward * rotate);
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
            //Set a rate at which we should turn
            float turnSpeed = rotationSpeed * Time.deltaTime;
            //Connect turning rate to horizonal motion for smooth transition
            float rotate = Input.GetAxis("Vertical") * turnSpeed;
            //            //Get current rotation
            float currentRotation = gameObject.transform.rotation.x;
            //            //Add current rotation to rotation rate to get new rotation
            Quaternion rotation = Quaternion.Euler(currentRotation + rotate, 0, 0);
            //            //Move object to new rotation
            gameObject.transform.rotation = rotation;
            gameObject.transform.Rotate(Vector3.back * rotate);
        }

        // move the gameobject
        transform.position = new Vector3(transform.position.x + moveHorizontal, transform.position.y, transform.position.z + moveVertical);

        // clamp the gameobject
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6, 6), transform.position.y, Mathf.Clamp(transform.position.z, -6, 6));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Car")
        {
            //destroy player car
        }
        if (collision.gameObject.tag == "CarSideCollider")
        {
            //destroy car
            Debug.Log("CarSideCollider!");
            Debug.Log($"{collision.gameObject.GetComponentInParent<GameObject>().name}");
        }
    }
}
