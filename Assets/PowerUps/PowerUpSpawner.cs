using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public float respawnDelay = 5f;

    private GameObject currentPowerUp;
    private float timer = 0f;
    public Transform spawnPoint;

    void Update()
    {
        if (currentPowerUp == null)
        {
            timer += Time.deltaTime;
            if (timer >= respawnDelay)
            {
                SpawnPowerUp();
                timer = 0f;
            }
        }
    }

    void SpawnPowerUp()
    {
        currentPowerUp = Instantiate(powerUpPrefab, spawnPoint.position, Quaternion.identity);
        PowerUpBehavior pu = currentPowerUp.GetComponent<PowerUpBehavior>();
        if (pu != null)
        {
            pu.spawner = this;
        }
    }

    
    public void NotifyPowerUpCollected()
    {
        currentPowerUp = null;
    }
}
