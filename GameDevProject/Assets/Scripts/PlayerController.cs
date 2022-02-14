using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce);
        }
    }
}
