using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    private Animator animator;
    private Rigidbody rb;
    private Vector3 movementDirection;

    void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        movementDirection = Vector3.zero;
	}
	
	void Update () {
	}

    void Move()
    {      
         //movementDirection = Input.GetAxis(Horizontal)
    }
}
