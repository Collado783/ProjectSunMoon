using System.Collections;
using UnityEngine;

public class BossMonitor : MonoBehaviour
{
    public GameObject boss;                 
    public BossDeath deathHandler;         

    private bool deathSequenceTriggered = false;

    void Update()
    {
       
        if (!deathSequenceTriggered && boss == null)
        {
            deathSequenceTriggered = true;
            StartCoroutine(DelayedDeathSequence());
        }
    }

    private IEnumerator DelayedDeathSequence()
    {
        yield return new WaitForSeconds(0.2f); 

        if (deathHandler != null)
        {
            deathHandler.HandleBossDeath();
        }
        else
        {
            Debug.LogWarning("DeathHandler no asignado");
        }
    }
}
