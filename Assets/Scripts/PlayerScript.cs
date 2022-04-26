using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    #region Player Declarations
    //Initialization of variables for Running
    private Rigidbody2D rb2d;//reference of the Rigidbody of the Player gameobject
    private Animator anime2r;
    private bool facingRight;
    [SerializeField]
    private float speed;
    #endregion

    #region Ground Checking Declarations
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask playerMask;
    #endregion

    #region HUD
    //declarations for scores
    [SerializeField]private Text scoreText;
    [SerializeField]private int scoreValue;
    private int result;

    //declarations for health
    [SerializeField]private Image health;
    [SerializeField]private float healthMaxValue;
    [SerializeField]private float healthCurrentvalue;
    [SerializeField]private float healthDeductionValue;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        rb2d = GetComponent<Rigidbody2D>();
        anime2r = GetComponent<Animator>();
        isGrounded = false;

        //------
        result = 0;
        scoreText.text = "000";
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(rb2d.transform.position, groundCheck.position, playerMask);//Linecasting
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovements(horizontal);
        Flip(horizontal);
    }

    void Update()
    {
        anime2r.SetBool("jumped", !isGrounded);//setting the jumped parameter in the Animator
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)//calls the Jump Method if the spacebar is pressed down!
        {
            //isGrounded = true;
            //anime2r.SetBool("jumped", isGrounded);
            Jump();
        }
    }

    private void Flip(float h)
    {
        if ((h > 0 && !facingRight) || (h < 0 && facingRight))
        {
            facingRight = !facingRight;

            Vector3 scale = transform.localScale;

            scale.x *= -1;

            transform.localScale = scale;
        }
    }

    private void HandleMovements(float h)
    {
        rb2d.velocity = new Vector2(h * speed, rb2d.velocity.y);
        anime2r.SetFloat("speed", Mathf.Abs(h));
    }

    private void Jump()
    {
        rb2d.velocity = Vector2.up * jumpForce;//calculates the Vector2 (0, 1)
    }

    private void ScoreManagement()
    {
        result = result + scoreValue;
        scoreText.text = result.ToString();
    }

    private void HealthManagement()
    {
        if (healthCurrentvalue == 0)
        {
            Debug.Log("Game Over");
        }else
        {
            Debug.Log("Current health: "+ healthCurrentvalue);
            health.fillAmount -= healthDeductionValue;
        }
        healthCurrentvalue = health.fillAmount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            ScoreManagement();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Orb") || (col.gameObject.tag == "Box"))
        {
            HealthManagement();
            Debug.Log("Enemy - " + col.gameObject.tag);
        }
    }
}
