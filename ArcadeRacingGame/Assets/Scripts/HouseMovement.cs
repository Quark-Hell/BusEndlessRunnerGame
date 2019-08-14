using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseMovement : MonoBehaviour
{
    int rand;
    float speed = 90;

    public bool leftRoad = false;

    Vector3 forward;

    // Update is called once per frame
    void Update()
    {

        if (leftRoad == false)
        {
            forward = transform.forward;
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        else
        {
            forward = transform.forward;
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
