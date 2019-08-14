using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLanes : MonoBehaviour
{
    public Transform collision;
    private Rigidbody rb;

    Vector3 targerPos;

    float horizontalVelocity = 0;
    public int laneNumber = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targerPos = new Vector3(2.5f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        targerPos = new Vector3(horizontalVelocity, 0, 0);
        collision.position = transform.position; 
        transform.position = Vector3.Lerp(transform.position, targerPos, 20 * Time.deltaTime);
        //rb.velocity = new Vector3(horizontalVelocity, 0, 0);

        if (Input.GetButtonDown("Fire1") && horizontalVelocity >= -2.5f)
        {
            horizontalVelocity += -2.5f;
            //StartCoroutine(stopSlide());
        }
        if (Input.GetButtonDown("Fire2") && horizontalVelocity <= 2.5f)
        {
            horizontalVelocity += 2.5f;
            //StartCoroutine(stopSlide());
        }

        // clamp the gameobject
        // transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5f, 5f), transform.position.y, Mathf.Clamp(transform.position.z, -6, 6));
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.2f);
        horizontalVelocity = 0;
    }
}
