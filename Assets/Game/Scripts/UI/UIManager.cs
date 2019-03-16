using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public GameObject HudObject { get; private set; }

    private static Canvas canvas { get; set; }

    [SerializeField]
    private Text livesText;
    [SerializeField]
    private Text pointText;
    [SerializeField]
    private GameObject gameOverState;
    private CanvasGroup gameOverCanvasGroup;
    private Image gameOverDimImage;
    private Text gameOverPoints;

    [SerializeField]
    private float gameOverTransitionSpeed = 0.1f;
    private float lerpIntensity;

    private void Start()
    {
        Instance = this;

        canvas = FindObjectOfType<Canvas>();
        HudObject = canvas.transform.Find("HUD").gameObject;
        gameOverCanvasGroup = gameOverState.GetComponent<CanvasGroup>();
        gameOverCanvasGroup.alpha = 0;
        gameOverDimImage = GameObject.Find("Game Over Dimmer").GetComponent<Image>();
        gameOverPoints = gameOverState.transform.Find("Points").GetComponent<Text>();
    }

	private void Update ()
    {
        livesText.text = $"Lives: {GameManager.Current.Lives}";
        pointText.text = $"Points: {GameManager.Current.Points}";

        if (GameManager.Current.Lives < 1)
        {
            if (gameOverCanvasGroup.alpha != 1)
            {
                gameOverState.transform.Translate(-Screen.width, 0, 0);
                gameOverCanvasGroup.alpha = 1;

                gameOverPoints.text = $"{GameManager.Current.Points} POINTS!";
            }

            lerpIntensity += gameOverTransitionSpeed * Time.deltaTime;

            if (gameOverState.transform.position.x != 0)
            {
                gameOverState.transform.position = Vector3.Lerp(gameOverState.transform.position,
                    new Vector3(Screen.width / 2f, gameOverState.transform.position.y, 0), lerpIntensity);
            }

            if (Input.GetMouseButton(0) && Mathf.Abs(gameOverState.transform.position.x - Screen.width / 2f) < 100)
            {
                SceneManager.LoadSceneAsync(0);
            }
            
            if (gameOverDimImage.color.a != 0.6f)
            {
                gameOverDimImage.color = Color.Lerp(gameOverDimImage.color,
                    new Color(gameOverDimImage.color.r, gameOverDimImage.color.g, gameOverDimImage.color.b, 0.6f), Time.deltaTime*2f);
            }
        }
	}
}
