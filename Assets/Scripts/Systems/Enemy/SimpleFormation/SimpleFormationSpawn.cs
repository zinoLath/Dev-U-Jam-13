using UnityEngine;

public class SimpleFormationSpawn : MonoBehaviour
{
    [SerializeField]
    private float _wait;

    private float _child_wait = 0;
    public float wait
    {
        get
        {
            return _child_wait + _wait;
        }
        set
        {
            _wait = wait;
        }
    }
    

    public void Awake()
    {
        SimpleFormation simpleFormation = GetComponent<SimpleFormation>();
        if (simpleFormation != null)
        {
            _child_wait = 0;
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<SimpleFormation>() != null)
                {
                    transform.GetChild(i).GetComponent<SimpleFormationSpawn>().Awake();
                }
                _child_wait += transform.GetChild(i).GetComponent<SimpleFormationSpawn>().wait;
            }
        }
    }
}