using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public Vector2 lastMovementDirection;
    private bool isPaused = false;
    public GameObject pauseMenuGameObject;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.velocity = movement * moveSpeed;

        if(moveHorizontal != 0 || moveVertical != 0)
        {
            lastMovementDirection = new Vector2(moveHorizontal, moveVertical).normalized;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenuGameObject.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenuGameObject.SetActive(false);
    }
}
