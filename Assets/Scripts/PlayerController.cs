using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public event System.Action OnPlayerDeath;
  public float speed = 7f;
  float screenHalfWidth;

  private void Start()
  {
    float halfPlayerWidth = transform.localScale.x / 2;
    screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
  }
  private void Update()
  {
    float inputX = Input.GetAxisRaw("Horizontal");
    float velocity = inputX * speed;
    transform.Translate(Vector2.right * velocity * Time.deltaTime);

    if (transform.position.x < -screenHalfWidth)
    {
      transform.position = new Vector2(screenHalfWidth, transform.position.y);
    }
    if (transform.position.x > screenHalfWidth)
    {
      transform.position = new Vector2(-screenHalfWidth, transform.position.y);
    }
  }

  private void OnTriggerEnter2D(Collider2D triggerCollider)
  {
    if (triggerCollider.tag == "Falling Block")
    {
      if (OnPlayerDeath != null)
      {
        OnPlayerDeath();
      }
      Destroy(gameObject);
    }
  }
}
