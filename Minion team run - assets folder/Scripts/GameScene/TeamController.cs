using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour
{

    [SerializeField] Rigidbody[] rb;

    [SerializeField] float moveSpeed = 5f;
    int actualLane = 1;
    [SerializeField] float delay1 = 0.1f;
    [SerializeField] float delay2 = 0.1f;
    [SerializeField] float jumpForce = 200f;
    [SerializeField] float jumpDelay = 1f;
	public Animator myAnimator1;
	public Animator myAnimator2;
	public Animator myAnimator3;
    bool jumping = false;

   // Animator anim;

    Coroutine moving;
    Coroutine jump;

    float[,] lane_x; // the first is the minion, the second the lane

    private void Awake()
    {
        lane_x = new float[,] { { -1.5f, 0f, 1.5f }, { -1.8f, -0.3f, 1.2f }, { -1.2f, 0.3f, 1.8f } };
    }

    private void Start()
    {
      //  anim = rb[0].GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (actualLane > 0 && !jumping)
            {

                moving = StartCoroutine(MovingTeam(false));
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (actualLane < 2 && !jumping)
            {
                if (moving != null) StopCoroutine(moving);
                moving = StartCoroutine(MovingTeam(true));
            }
        }

        else if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            if (jump != null) StopCoroutine(jump);
           // anim.Play("Jump");
            jump = StartCoroutine(JumpingTeam());
        }

	}

    private IEnumerator MovingTeam(bool right)
    {
        if (right)
        {

            actualLane++;
            StartCoroutine(MovingToRight(0));
            yield return new WaitForSeconds(delay1);
            StartCoroutine(MovingToRight(1));
            yield return new WaitForSeconds(delay2 - delay1);
            StartCoroutine(MovingToRight(2));

            if (rb[0] != null) StartCoroutine(MovingToRight(0));
            yield return new WaitForSeconds(delay1);
            if (rb[1] != null) StartCoroutine(MovingToRight(1));
            yield return new WaitForSeconds(delay2-delay1);
            if (rb[2] != null) StartCoroutine(MovingToRight(2));
        }
        else
        {
            actualLane--;

            StartCoroutine(MovingToLeft(0));

            if (rb[0] != null) StartCoroutine(MovingToLeft(0));

            yield return new WaitForSeconds(delay1);
            if (rb[1] != null) StartCoroutine(MovingToLeft(1));
            yield return new WaitForSeconds(delay2);

            StartCoroutine(MovingToLeft(2));

            if (rb[2] != null) StartCoroutine(MovingToLeft(2)); 

        }
        yield break;
    }
    IEnumerator MovingToLeft(int minion)
    {
        while (true)
        {
            if (rb[minion] == null)
            {
                yield break;
            }
            else
            {
                rb[minion].velocity = new Vector3(-1 * moveSpeed, rb[minion].velocity.y, rb[minion].velocity.z);
                yield return new WaitForFixedUpdate();

                if (rb[minion].transform.position.x <= lane_x[minion, actualLane])
                {
                    rb[minion].velocity = Vector3.zero;
                    yield break;
                }
            }
        }
    }
    IEnumerator MovingToRight(int minion)
    {
        while (true)
        {
            if (rb[minion] == null)
            {
                yield break;
            }
            else
            {
                rb[minion].velocity = new Vector3(1 * moveSpeed, rb[minion].velocity.y, rb[minion].velocity.z);
                yield return new WaitForFixedUpdate();

                if (rb[minion].transform.position.x >= lane_x[minion, actualLane])
                {
                    rb[minion].velocity = Vector3.zero;
                    yield break;
                }
            }
        }
    }

    IEnumerator JumpingTeam()
    {
        jumping = true;
        if (rb[0] != null)
        {
            Jump(0);
            myAnimator1.SetTrigger("jumping");
        }
        yield return new WaitForSeconds(delay1);
        if (rb[1] != null)
        {
            Jump(1);
            myAnimator2.SetTrigger("jumping");
        }
		yield return new WaitForSeconds(delay2 - delay1);
        if (rb[2] != null)
        {
            Jump(2);
            myAnimator3.SetTrigger("jumping");
        }
		yield return new WaitForSeconds(jumpDelay);
        jumping = false;
        yield break;
    }
    void Jump(int minion)
    {
        rb[minion].AddForce(Vector3.up * jumpForce);
		// rb[minion].GetComponent<Animator>().Play("Jump");
    }

    public void CheckTeamNumber()
    {
        StartCoroutine(Checking()); 
    }

    IEnumerator Checking()
    {
        yield return new WaitForSeconds(0.2f);
        if (transform.childCount == 0) GameMaster.GameOver();
        yield break; 
    }

}
