using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float horizontalSpeed = 5f;
    private float minX = -4.5f;
    private float maxX = 4.5f;
    public TMP_Text distanceText; // Αναφορά στο UI TextMeshProUGUI στο Canvas
    public TMP_Text coinsText;
    private float startZ;
    private float distance = 0f;
    public int coins = 0;

    void Start()
    {
        startZ = transform.position.z; // Αποθήκευση αρχικής θέσης Z
        UpdateUI();
    }

    void Update()
    {
        // Μετακίνηση προς τα εμπρός
        transform.position += Vector3.forward * speed * Time.deltaTime;

        // Υπολογισμός απόστασης από το αρχικό σημείο
        distance = transform.position.z - startZ;

        // Ενημέρωση UI
        UpdateUI();

        // Οριζόντια μετακίνηση
        float moveInput = Input.GetAxis("Horizontal");
        float moveAmount = moveInput * horizontalSpeed * Time.deltaTime;

        float newX = Mathf.Clamp(transform.position.x + moveAmount, minX, maxX);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            UpdateUI();

            // Find and play the CSfx sound
            GameObject coinSoundObj = GameObject.Find("CSfx");
            if (coinSoundObj != null)
            {
                AudioSource audioSource = coinSoundObj.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }

            Destroy(other.gameObject);
        }

        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("sigma");
            SceneManager.LoadScene("EndScene");
        }
    }

    void UpdateUI()
    {
        if (distanceText != null)
        {
            distanceText.text = "Distance: " + distance.ToString("F2") + "m";
        }
        coinsText.text = "Coins Collected: " + coins;
    }
}