using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonePosition : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float rotationTime;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, player.transform.rotation, rotationTime);
    }
}
