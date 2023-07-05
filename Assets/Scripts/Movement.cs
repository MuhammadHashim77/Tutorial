using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    Vector3 movement;
    
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        

        movement = new Vector3(horizontal, 0, vertical) * movementSpeed * Time.deltaTime;

        transform.position += movement;

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("IsJump", true);
        }
        else
        {
            animator.SetBool("IsJump", false);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("IsPunching", true);
        }
        else
        {
            animator.SetBool("IsPunching", false);
        }

        if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("IsDancing", true);
        }
        else
        {
            animator.SetBool("IsDancing", false);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouching", true);
        }
        else
        {
            animator.SetBool("IsCrouching", false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "DeathOrb")
        {
            Destroy(gameObject);
        }
    }

}
