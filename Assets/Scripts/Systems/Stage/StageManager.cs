using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageManager : MonoBehaviour
{
    public List<EnemyFormation> enemyFormations;
    IEnumerator Start()
    {
        while (true)
        {
            EnemyFormation currFormation = enemyFormations[Random.Range((int)0,(int)enemyFormations.Count-1)];
            EnemyFormation obj = Instantiate(currFormation);

            yield return obj.ExecuteFormation();
            
            yield return new WaitForSeconds(3f);
        }
    }
}