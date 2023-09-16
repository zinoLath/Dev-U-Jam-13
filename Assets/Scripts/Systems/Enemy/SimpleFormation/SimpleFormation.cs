using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleFormation : MonoBehaviour
{
    public virtual IEnumerator ExecuteFormation()
    {
        int i = 0;
        while (true)
        {
            if (i >= transform.childCount)
            {
                break;
            }

            transform.GetChild(i).gameObject.SetActive(true);
            
            yield return new WaitForSeconds(transform.GetChild(i).GetComponent<SimpleFormationSpawn>().wait);
        }
    }
}