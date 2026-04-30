using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectMoving : MonoBehaviour

{

    public float min = 2f;
    public float max = 3f;
    public Transform platform;
    public Transform player;
    // Use this for initialization

    void Start()

    {

        min = transform.position.x;
        max = transform.position.x + 3;

    }

    // Update is called once per frame

    void Update()

    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
       player.SetParent(platform);

    }

    private void OnTriggerExit2D(Collider2D collision)

    {
        player.SetParent(null);

    }

}

