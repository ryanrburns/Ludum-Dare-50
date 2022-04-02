using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaxForm : MonoBehaviour
{
    [SerializeField] TMP_InputField deductionField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Compute()
    {
        Debug.Log("Pressed Compute");
        if (deductionField.text == "8008")
        {
            Debug.Log("I was correct");
        }
        else
        {
            Debug.Log("INCCORECT");
        }
    }
}
