using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlCont : MonoBehaviour
{
    //PUBLIC VARIABLES
    public float speed = 10.0f;
    public float jumpForce = 500;
    public Text score;
    public Text info;

    //PRIVATE VARIABLES
    private Rigidbody2D rBody;
    private Animator anim;
    private bool isFacingRight = true;
    private bool isGrounded = false;
    private int _score;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _score=0;
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy();
    }
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
                Destroy(this.info);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rBody.AddForce(new Vector2(0, jumpForce));           
            isGrounded = false;
            anim.SetBool("isJump",true);
        }
        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);
        // check direction of the private void OnPlayerConnected(NetworkPlayer player) {
        if (horiz < 0 && isFacingRight)
        {
            Flip();
        }
        else if (horiz > 0 && !isFacingRight)
        {
            Flip();
        }

        //update animator information
        anim.SetFloat("speed", Mathf.Abs(horiz));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isJump", false);
        }
        if(other.gameObject.CompareTag("Cherry"))
        {
            this._score+=50;
            this.score.text="Score: "+this._score;
            Destroy(other.gameObject);
        }
    }
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }
}
