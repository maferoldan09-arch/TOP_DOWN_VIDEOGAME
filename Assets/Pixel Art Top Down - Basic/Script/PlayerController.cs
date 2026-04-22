using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Se agrega para poder reiniciar la escena

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;

    // Contadores de flores 
    public int flores = 0;
    public int totalFlores = 60;

    public int flores2 = 0;
    public int totalFlores2 = 20;

    // Objeto especial de victoria
    public int cofres = 0;

    // Estados del juego
    public bool hasCofre = false;
    public bool hasTumba = false;

    // Textos de UI separados para cada contador
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI floresText;
    public TextMeshProUGUI flores2Text;
    public TextMeshProUGUI cofresText;
    public TextMeshProUGUI notificationText;

    void Start()
    {
        // Se inicializan los textos al iniciar el juego
        UpdateScore();
        UpdateFlores();
        UpdateFlores2();
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
        // Flores de 1 punto
        if(other.CompareTag("Collectable"))
        {
            flores++;
            score += 1;

            UpdateFlores();
            UpdateScore();

            ShowNotification("Flor recogida");

            Destroy(other.gameObject);
        }

        // Flores de 2 puntos
        if(other.CompareTag("Collectable_2"))
        {
            flores2++;
            score += 2;

            UpdateFlores2();
            UpdateScore();

            ShowNotification("Flor especial recogida");

            Destroy(other.gameObject);
        }

        // Cofre de victoria
        if(other.CompareTag("Cofre"))
        {
            cofres++;
            hasCofre = true;
            score += 5;

            UpdateCofres();
            UpdateScore();

            ShowNotification("¡Ganaste!");
            Debug.Log("Ganaste");

            Destroy(other.gameObject);
        }

        // Tumba para derrota
        if(other.CompareTag("Tumba"))
        {
            hasTumba = true;

            ShowNotification("Game Over");
            Debug.Log("Game Over");

            // Se retrasa el reinicio para que el mensaje sea visible
            Invoke("ReiniciarEscena", 2f);
        }
    }

    // Actualizar la UI

    void UpdateScore()
    {
        if(scoreText != null)
            scoreText.text = "Puntaje: " + score;
    }

    void UpdateFlores()
    {
        if(floresText != null)
            floresText.text = "Flores: " + flores + "/" + totalFlores;
    }

    void UpdateFlores2()
    {
        if(flores2Text != null)
            flores2Text.text = "Flores especiales: " + flores2 + "/" + totalFlores2;
    }

    void UpdateCofres()
    {
        if(cofresText != null)
            cofresText.text = "Cofres: " + cofres;
    }

    void ShowNotification(string message)
    {
        if(notificationText != null)
            notificationText.text = message;
    }

    // Para reiniciar la escena al morir
    void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}