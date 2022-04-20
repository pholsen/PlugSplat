using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private Vector2 firstPos;
    [SerializeField] private Vector2 secondPos;
    [SerializeField] private Vector2 currentPos;

    [SerializeField] private float moveSpeed;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentPos = new Vector2(secondPos.x - firstPos.x, secondPos.y - firstPos.y);
        }

        currentPos.Normalize();

        if (currentPos.y < 0 && currentPos.x > -0.5f && currentPos.x < 0.5f)
        {
            //Down
            rb.velocity = Vector3.back * moveSpeed;
            gameObject.transform.rotation = Quaternion.Euler(90f, 180f, 0f);
        }
        else if (currentPos.y>0 && currentPos.x > -0.5f && currentPos.x < 0.5f)
        {
            //Up
            rb.velocity = Vector3.forward * moveSpeed;
            gameObject.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
        else if (currentPos.x < 0 && currentPos.y > -0.5f && currentPos.y < 0.5f)
        {
            //Left
            rb.velocity = Vector3.left * moveSpeed;
            gameObject.transform.rotation = Quaternion.Euler(90f, -90f, 0f);
        }
        else if (currentPos.x > 0 && currentPos.y > -0.5f && currentPos.y < 0.5f)
        {
            //Right
            rb.velocity = Vector3.right * moveSpeed;
            gameObject.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GroundPast")
        {
            Debug.Log(31);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        
    }
    void Update()
    {
        Swipe();
    }
}
