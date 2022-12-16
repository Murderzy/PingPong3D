using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    private Rigidbody rb;

    [SerializeField]
    private bool isPlayer = true;

    [SerializeField]
    private float offset = 0.2f;

    private Transform ball;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isPlayer)
        {
            MoveByPlayer();
        }
        else
        {
            MoveByComputer();
        }

        
    }

    private void MoveByPlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
            //rb.velocity = Vector3.forward * Speed * Time.deltaTime;
            rb.AddForce(Vector3.back * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            //rb.velocity = Vector3.back * Speed * Time.deltaTime;
            rb.AddForce(Vector3.forward * Speed * Time.deltaTime);
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void MoveByComputer()
    {
        if(ball.position.z > transform.position.z + offset)
        {
            rb.AddForce(Vector3.back * Speed * Time.deltaTime);
        }
        else if(ball.position.z<transform.position.z + offset)
        {
            rb.AddForce(Vector3.forward * Speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
