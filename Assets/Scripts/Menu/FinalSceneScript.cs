using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalSceneScript : MonoBehaviour
{
    public float _finalScore = 0;
    [SerializeField] private TextMeshProUGUI _text;

    void Start()
    {
        Debug.Log(_finalScore);
        _text.text = _finalScore.ToString();
    }
}
