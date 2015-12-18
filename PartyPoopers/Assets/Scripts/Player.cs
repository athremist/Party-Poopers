using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    //This class is a testing prototype. It will be removed later.

    Vector3 movement;
    float horizontal;
    float vertical;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0.0f, vertical);

        transform.Translate(movement * Time.deltaTime * 5);
    }
}
