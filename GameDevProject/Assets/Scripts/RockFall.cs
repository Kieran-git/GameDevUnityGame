using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFall : MonoBehaviour
{
    bool Collided = false;
    private void OnCollisionEnter(Collision collision)
    {
        // After the first collision stop adding shrink scripts
        if(Collided == false && collision.gameObject.name == "Player")
        {
            gameObject.AddComponent<Shrinking>();
            Collided = true;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Only try increase size when not collided
        if (Collided == false)
        {
            if(transform.localScale.x <= 4f)
            {
                transform.localScale += new Vector3(1f, 1f, 1f) * Time.deltaTime;
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
