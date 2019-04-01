using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Vector3 currentPos;
    public Vector3 nextPos;
    private Vector3 direction;
    private Animator animator;
    public float speed = 2f;

	// Use this for initialization
	void Start ()
    {
        currentPos = new Vector3(1,1,0);
        nextPos = currentPos;
        direction = Vector3.zero;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.UpArrow))
        {
            nextPos = currentPos + Vector3.up;
            direction = Vector3.up;
            animator.Play("Up");
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            nextPos = currentPos + Vector3.down;
            direction = Vector3.down;
            animator.Play("Down");
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            nextPos = currentPos + Vector3.left;
            direction = Vector3.left;
            animator.Play("Left");
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            nextPos = currentPos + Vector3.right;
            direction = Vector3.right;
            animator.Play("Right");
        }
        int row = (int)nextPos.y;
        int col = (int)nextPos.x;
        if (GameManager.Instance.map[row, col] != null)
            nextPos = currentPos;
        if(Vector3.Distance(transform.position, nextPos) >= 0.05f)
        {
            transform.position = transform.position + direction * Time.deltaTime * speed;
        }
        else
        {
            currentPos = nextPos;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetBomb();
        }
	}

    void SetBomb()
    {
        Instantiate(GameManager.Instance.bomb, currentPos, Quaternion.identity);
    }
}
