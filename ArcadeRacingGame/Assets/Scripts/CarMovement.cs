using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    int rand;
    float speed;
    bool hit = false; //hit by a player

    Rigidbody rb;

    public bool leftRoad = false;

    Vector3 forward;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rand = Random.Range(0, 3);

        if(rand == 0)
        {
            speed = 20;
        }
        else if(rand == 1)
        {
            speed = 40;
        }
        else if(rand == 2 && leftRoad == true)
        {
            speed = 60;
        }
        else
        {
            speed = 30;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (leftRoad == false && hit == false)
        {
            forward = -transform.forward;
            transform.Translate(Vector3.back * Time.deltaTime * (speed * (GameSettings.Difficulty/10)));
        }
        else if (leftRoad == true && hit == false)
        {
            forward = transform.forward;
            transform.Translate(Vector3.forward * Time.deltaTime * (speed * (GameSettings.Difficulty / 10)));
        }

        CheckForCollider();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            hit = true;
        }
    }

    private void CheckForCollider()
    {
        RaycastHit objectHitToPlayer; //raycast in the players direction
        // Shoot raycast
        Vector3 rayPos = new Vector3(transform.position.x, 1, transform.position.z);
        Debug.DrawRay(rayPos, forward * 6, Color.green);
        if (Physics.Raycast(rayPos, forward, out objectHitToPlayer, 6))
        {
            if (objectHitToPlayer.collider.tag == "Car")
            {
                Debug.Log("Close to enemy");
                speed = 20;
            }
            if (objectHitToPlayer.collider.tag == "Player")
            {
                Debug.Log("Player hit");
                rb.AddForce(transform.forward * -speed);
            }
        }

        RaycastHit objectHitLeft;
        
        Debug.DrawRay(rayPos, Vector3.left * 1.2f, Color.blue);
        if (Physics.Raycast(rayPos, Vector3.left, out objectHitLeft, 1.2f))
        {
            if (objectHitLeft.collider.tag == "Car")
            {
                Debug.Log("Close to enemy");
            }
            if (objectHitLeft.collider.tag == "Player")
            {
                Debug.Log("Player hit");
                rb.AddForce(Vector3.left * -speed);
            }
        }

        RaycastHit objectHitRight;
        
        Debug.DrawRay(rayPos, Vector3.right * 1.2f, Color.blue);
        if (Physics.Raycast(rayPos, Vector3.right, out objectHitRight, 1.2f))
        {
            if (objectHitRight.collider.tag == "Car")
            {
                Debug.Log("Close to enemy");
            }
            if (objectHitRight.collider.tag == "Player")
            {
                Debug.Log("Player hit");
                rb.AddForce(Vector3.right * -speed);
            }
        }
    }
}
