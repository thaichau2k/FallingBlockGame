using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  public GameObject gameOverScreen;
  public Text score;
  bool isGameOver;
  // Start is called before the first frame update
  void Start()
  {
    FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
  }

  // Update is called once per frame
  void Update()
  {
    if (isGameOver)
    {
      if (Input.GetKeyDown(KeyCode.R))
      {
        SceneManager.LoadScene(0);
      }
    }
  }

  public void OnGameOver()
  {
    gameOverScreen.SetActive(true);
    score.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
    isGameOver = true;
  }
}
