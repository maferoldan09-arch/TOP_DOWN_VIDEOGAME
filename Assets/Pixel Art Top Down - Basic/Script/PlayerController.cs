using UnityEngine;
using TMPro; 

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;

    public bool hasCofre = false;  
    public bool hasTumba = false;   

    public TextMeshProUGUI textScore; 
    public TextMeshProUGUI notificationText;

    void Start()
    {
       UpdateTextScore(); 
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Collectable"))
        {
            score = score + 1;

            UpdateTextScore();
            ShowNotification("Collected!"); 

            Destroy(other.gameObject);
            Debug.Log("Collected!");
            Debug.Log("Score: " + score);
        }

        if(other.CompareTag("Cofre"))
        {
            hasCofre = true;
            score = score + 5;

            UpdateTextScore();
            ShowNotification("Encontraste el cofre!"); 

            Debug.Log("Encontraste el cofre!");
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Tumba"))
        {
            hasTumba = true;

            ShowNotification("Has tocado la runa, no puedes ganar");

            Debug.Log("Has tocado la runa, no puedes ganar");
        }
                
        if (score >= 3 && hasCofre == true && !hasTumba)
        {
          ShowNotification("Ganaste!");

            Debug.Log("Ganaste!");
        }
    }

    void UpdateTextScore()
    {
        textScore.text = "Score: " + score;
    }

    void ShowNotification(string message)
    {
     notificationText.text = message; 
    }
}