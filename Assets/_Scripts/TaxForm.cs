using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TaxForm : MonoBehaviour
{
    [SerializeField] TMP_InputField textFieldSocial;
    [SerializeField] TMP_InputField textFieldIncome;
    [SerializeField] TMP_InputField textFieldStudent;
    [SerializeField] TMP_InputField textFieldWork;

    [SerializeField] ToggleGroup toggleGroupMaritalStatus;
    [SerializeField] ToggleGroup toggleGroupEntity;
    [SerializeField] Toggle toggleBirthdate;
    [SerializeField] Toggle toggleIsClone;

    [SerializeField] TMP_Dropdown dropdownSpecies;

    bool completedSocial;
    bool completedIncome;
    bool completedStudent;
    bool completedWork;
    bool completedMaritalStatus;
    bool completedEntity;
    bool completedBirthdate;
    bool completedIsClone = true;
    bool completedSpecies;

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
        CheckSocialText();
        CheckIncomeText();
        CheckStudentText();
        CheckWorkText();
        CheckMaritalToggleGroup();
        CheckEntityToggleGroup();
        CheckBirthdateToggle();
        CheckSpeciesDropdown();

        ComputeWin();
    }

    private void ComputeWin()
    {
        if (!completedSocial) { return; }
        if (!completedIncome) { return; }
        if (!completedStudent) { return; }
        if (!completedWork) { return; }
        if (!completedMaritalStatus) { return; }
        if (!completedEntity) { return; }
        if (!completedBirthdate) { return; }
        if (!completedSpecies) { return; }
        else
        {
            Debug.Log("FUCKING WINNING");
        }
    }

    private void CheckSocialText()
    {
        if (textFieldSocial.text == "0")
        {
            completedSocial = true;
            Debug.Log("completedSocial: True");
        }
        else
        {
            completedSocial = false;
            Debug.Log("completedSocial: False");
        }

    }

    private void CheckIncomeText()
    {
        if (textFieldIncome.text == "0")
        {
            completedIncome = true;
            Debug.Log("completedIncome: True");
        }
        else
        {
            completedIncome = false;
            Debug.Log("completedIncome: False");
        }
    }
    private void CheckStudentText()
    {
        if (textFieldStudent.text == "0")
        {
            completedStudent = true;
            Debug.Log("completedStudent: True");
        }
        else
        {
            completedStudent = false;
            Debug.Log("completedStudent: False");
        }
    }

    private void CheckWorkText()
    {
        if (textFieldWork.text == "0")
        {
            completedWork = true;
            Debug.Log("completedWork: True");
        }
        else
        {
            completedWork = false;
            Debug.Log("completedWork: False");
        }
    }

    private void CheckMaritalToggleGroup()
    {
        if (toggleGroupMaritalStatus.AnyTogglesOn() == true)
        {
            if (toggleGroupMaritalStatus.GetFirstActiveToggle().ToString() == "Single (UnityEngine.UI.Toggle)")
            {
                completedMaritalStatus = true;
                Debug.Log("completedMaritalStatus: True");
            }
            else
            {
                completedMaritalStatus = false;
                Debug.Log("completedMaritalStatus: False");
            }
        }
        else
        {
            completedMaritalStatus = false;
            Debug.Log("completedMaritalStatus: False");
        }
    }

    private void CheckEntityToggleGroup()
    {
        if (toggleGroupEntity.AnyTogglesOn() == true)
        {
            if (toggleGroupEntity.GetFirstActiveToggle().ToString() == "Entity (UnityEngine.UI.Toggle)")
            {
                completedEntity = true;
                Debug.Log("completedEntity: True");
            }
            else
            {
                completedEntity = false;
                Debug.Log("completedEntity: False");
            }
        }
        else
        {
            completedEntity = false;
            Debug.Log("completedEntity: False");
        }
    }

    private void CheckBirthdateToggle()
    {
        if(toggleBirthdate.isOn == true)
        {
            completedBirthdate = true;
            Debug.Log("completedBirthdate: true");
        }
        else
        {
            completedBirthdate = false;
            Debug.Log("completedBirthdate: false");
        }
    }

    private void CheckSpeciesDropdown()
    {
        if (dropdownSpecies.value == 1)
        {
            completedSpecies = true;
            Debug.Log("completedSpecies: true");
        }
        else
        {
            completedSpecies = false;
            Debug.Log("completedBirthdate: false");
        }
    }
}
