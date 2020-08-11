using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public Animator animator;

    private int score;
    public Text scoreText;

    public Text timerText;
    public float startTime = 10f;
    float currentTime = 0f;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotation = 0.0f;
    public float rotationSpeed = 80.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        //transform.Rotate(0, 180, 0);
        currentTime = startTime;
        score = 0;
        showScore();
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("0");

        if (characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetInteger("condition", 1);
                moveDirection = new Vector3(0, 0, -1);
                moveDirection *= speed;
                moveDirection = transform.TransformDirection(moveDirection);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetInteger("condition", 0);
                moveDirection = new Vector3(0, 0, 0);
            }
            if (Input.GetKeyDown("space"))
            {
                animator.SetInteger("condition", 2);
                SoundManager.sound("jump");
                moveDirection.y = jumpSpeed;
                //animator.SetInteger("condition", 0);
            }
        }
        rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

        if (currentTime <= 0)
        {
            currentTime = 0;
            gameOver();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            SoundManager.sound("death");
            Destroy(other.gameObject);
            score++;
            showScore();
            Debug.Log("Item Collected");
        }
        if(other.gameObject.CompareTag("GoldItem"))
        {
            SoundManager.sound("death");
            Destroy(other.gameObject);
            score = score + 3;
            showScore();
            Debug.Log("Gold Item Collected");
        }
        if(other.gameObject.CompareTag("BadItem"))
        {
            SoundManager.sound("death");
            Destroy(other.gameObject);
            score--;
            showScore();
            Debug.Log("Bad Item Collected");
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            //burn++;
            Debug.Log("Player burned");
            gameOver();
        }
        if(other.gameObject.CompareTag("Bounds"))
        {
            Debug.Log("Out of Bounds");
            gameOver();
        }
        
    }

    void showScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void gameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
