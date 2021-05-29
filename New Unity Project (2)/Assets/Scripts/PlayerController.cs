using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidbody;
    public float speed = 8f;
    public int PlayerLife = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;


        if (Input.GetKeyDown(KeyCode.R))
        {
            ReStart();

        }
    }

    public void ReStart()
    {
        PlayerLife = 5;

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.DisplayLife(PlayerLife);
    }


    public void Detect()
    {
        PlayerLife--;

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.DisplayLife(PlayerLife);

        //GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        //bullet.transform.LookAt(target);

        if (PlayerLife <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.EndGame();
    }
}
