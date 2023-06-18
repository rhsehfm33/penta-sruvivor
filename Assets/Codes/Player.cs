using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVector;
    public float speed;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");
    }

	private void FixedUpdate()
	{
        Vector2 nextVector = inputVector.normalized * speed * Time.fixedDeltaTime;
		rigid.MovePosition(rigid.position + nextVector);
	}
}
