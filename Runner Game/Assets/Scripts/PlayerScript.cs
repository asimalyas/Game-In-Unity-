using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public Rigidbody rb;
    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float acceleration = 0.3f;
    [SerializeField] private float maxSpeed = 15f;
    [SerializeField] private float controlKeysSpeed = 5f;
    private float currentSpeed;
    private float control;
    public TMP_Text text;
    public TMP_Text scoreBoard; // UI Text to show only score after game over
    public int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = baseSpeed;
        score = 0;
        scoreBoard.gameObject.SetActive(false); // Hide scoreboard initially
        UpdateUIText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 6f, ForceMode.VelocityChange);
        }

        control = Input.GetAxis("Horizontal"); 
        rb.linearVelocity = new Vector3(control * controlKeysSpeed, rb.linearVelocity.y, currentSpeed);
    }

    void FixedUpdate()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        UpdateUIText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("point"))
        {
            score++;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
            UpdateUIText();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("out"))
        {
            text.gameObject.SetActive(false); // Hide speed & score UI
            scoreBoard.gameObject.SetActive(true); // Show only score
            scoreBoard.text = "Final Score: " + score;

            Invoke("EndGame", 2f); // Wait 2 seconds before restarting
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    private void UpdateUIText()
    {
        text.text = $"Speed: {currentSpeed:0} | Score: {score}";
    }
}
