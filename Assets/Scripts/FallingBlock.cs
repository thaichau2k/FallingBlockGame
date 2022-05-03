using UnityEngine;

public class FallingBlock : MonoBehaviour
{
  public Vector2 speedMinMax;
  float speed;
  float visisbleHeightThreshold;
  private void Start()
  {
    speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
    visisbleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
  }
  void Update()
  {
    transform.Translate(Vector2.down * speed * Time.deltaTime, Space.Self);
    if (transform.position.y < visisbleHeightThreshold) Destroy(gameObject);
  }
}
