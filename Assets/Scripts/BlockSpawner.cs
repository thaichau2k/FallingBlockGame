
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
  public GameObject fallingBlockPrefab;
  public Vector2 blockSizeMinMax;
  public float spawnAngleMax;
  public Vector2 secondsBetweenSpawnMinMax;
  float nextSpawnTime;
  Vector2 screenHalfSize;
  // Start is called before the first frame update
  void Start()
  {
    screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
  }

  // Update is called once per frame
  void Update()
  {
    if (Time.time > nextSpawnTime)
    {
      float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnMinMax.y, secondsBetweenSpawnMinMax.x, Difficulty.GetDifficultyPercent());
      nextSpawnTime = Time.time + secondsBetweenSpawns;

      float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
      float blockSize = Random.Range(blockSizeMinMax.x, blockSizeMinMax.y);
      Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + blockSize);
      GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
      newBlock.transform.localScale = Vector2.one * blockSize;
    }
  }
}
