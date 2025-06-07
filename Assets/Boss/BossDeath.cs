using UnityEngine;

public class BossDeath : MonoBehaviour
{
    [Header("Sun Settings")]
    public GameObject sunPrefab;
    public Transform sunSpawnPoint;
    public float sunDescendSpeed = 1f;
    

    private bool hasHandledDeath = false;

    private void OnDestroy()
    {
        if (!hasHandledDeath) 
        {
            HandleBossDeath();
            hasHandledDeath = true;
        }
    }

    public void HandleBossDeath()
    {
        DestroyAllEnemiesAndProjectiles();
        SpawnSun();
    }

    private void DestroyAllEnemiesAndProjectiles()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
            Destroy(obj);

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("BossProjectile"))
            Destroy(obj);
    }

    private void SpawnSun()
    {
        GameObject sun = Instantiate(sunPrefab, sunSpawnPoint.position, Quaternion.identity);
        SunBehavior sunScript = sun.AddComponent<SunBehavior>();
        sunScript.Initialize(sunDescendSpeed);
    }
}
