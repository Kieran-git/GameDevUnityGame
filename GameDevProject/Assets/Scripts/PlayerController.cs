using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce;
    public GameObject RockPrefab;
    bool CanJump;

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        CanJump = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        CanJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.I)) Instantiate(RockPrefab, transform.position + Vector3.up * 3, Quaternion.identity);
    }

    void PlayerMovement()
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
        if (Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce);
        }
    }
}
