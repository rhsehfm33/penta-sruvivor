using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVector;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

	void FixedUpdate()
	{
        Vector2 nextVector = inputVector * speed * Time.fixedDeltaTime;
		rigid.MovePosition(rigid.position + nextVector);
	}

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVector.magnitude);
        if (inputVector.x != 0)
        {
            spriter.flipX = inputVector.x < 0;
        }
    }
}
