using UnityEngine;
using TMPro; 

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    // PUNTAJE TOTAL
    public int score = 0;

    // CONTADORES
    public int monedas = 0;
    public int totalMonedas = 60;

    public int cofres = 0;
    public int totalCofres = 2;

    public bool hasCofre = false;
    public bool hasTumba = false;

    // EXTOS UI
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI monedasText;
    public TextMeshProUGUI cofresText;
    public TextMeshProUGUI notificationText;

    void Start()
    {
        UpdateScore();
        UpdateMonedas();
        UpdateCofres();
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
        // MONEDAS
        if(other.CompareTag("Collectable"))
        {
            monedas++;
            score += 1;

            UpdateMonedas();
            UpdateScore();

            ShowNotification("Flor recogida!");

            Destroy(other.gameObject);
            Debug.Log("Flor recogida");
        }

        // COFRE
        if(other.CompareTag("Cofre"))
        {
            cofres++;
            hasCofre = true;
            score += 5;

            UpdateCofres();
            UpdateScore();

            ShowNotification("Cofre recogido!");

            Destroy(other.gameObject);
            Debug.Log("Cofre recogido");
        }

        // TUMBA
        if(other.CompareTag("Tumba"))
        {
            hasTumba = true;

            ShowNotification("Has tocado una tumba");

            Debug.Log("Has tocado la tumba");
        }

        // CONDICION DE VICTORIA
        if (monedas == totalMonedas && cofres == totalCofres && !hasTumba)
        {
            ShowNotification("¡Ganaste!");
            Debug.Log("Ganaste!");
        }
    }

    // ACTUALIZAR UI

    void UpdateScore()
    {
        if(scoreText != null)
            scoreText.text = "Puntaje: " + score;
    }

    void UpdateMonedas()
    {
        if(monedasText != null)
            monedasText.text = "Monedas: " + monedas + "/" + totalMonedas;
    }

    void UpdateCofres()
    {
        if(cofresText != null)
            cofresText.text = "Cofres: " + cofres + "/" + totalCofres;
    }

    void ShowNotification(string message)
    {
        if(notificationText != null)
            notificationText.text = message; 
    }
}