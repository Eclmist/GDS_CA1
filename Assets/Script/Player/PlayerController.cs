using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    private Animator anim;
    private Rigidbody rb;

    private bool passiveMode;

    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        passiveMode = true;
    }
	
	void FixedUpdate () {
        Move();

        AnimUpdate();

	}

    void Move()
    {
        if (passiveMode)
        {
            //calculate movement direction
            Vector3 forwardVector = Input.GetAxis("Vertical") * Camera.main.transform.forward;
            forwardVector.y = 0;

            Vector3 moveVector = Input.GetAxis("Horizontal") * Camera.main.transform.right +
                forwardVector;

            rb.velocity = moveVector.normalized * moveSpeed;

            transform.LookAt(transform.position + rb.velocity + Camera.main.transform.forward);
        }
    }

    void AnimUpdate()
    {
        anim.SetFloat("Forward", rb.velocity.magnitude);
    }
}
