using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TaxForm : MonoBehaviour
{
    [Header("Tax Form Fields")]
    [SerializeField] TMP_InputField textFieldSocial;
    [SerializeField] TMP_InputField textFieldIncome;
    [SerializeField] TMP_InputField textFieldStudent;
    [SerializeField] TMP_InputField textFieldWork;

    [SerializeField] ToggleGroup toggleGroupMaritalStatus;
    [SerializeField] ToggleGroup toggleGroupEntity;
    [SerializeField] Toggle toggleBirthdate;
    [SerializeField] Toggle toggleIsClone;

    [SerializeField] TMP_Dropdown dropdownSpecies;

    [Header("Answer Fields from Desk")]
    [SerializeField] TMP_Text answerSocial;
    [SerializeField] TMP_Text answerWage;
    [SerializeField] TMP_Text answerStudent;
    [SerializeField] TMP_Text answerWork;

    private string[] possibleSpecies = new string[3];
    private string[] possiblePlanets = new string[3];

    bool completedSocial;
    bool completedIncome;
    bool completedStudent;
    bool completedWork;
    bool completedMaritalStatus;
    bool completedEntity;
    bool completedBirthdate;
    bool completedIsClone = true;
    bool completedSpecies;

    [SerializeField] Button submitButton;
    [SerializeField] TMP_Text finalSignature;

    AudioPlayer audioPlayer;

    int randomArrayValue;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        MakeArrays();
        Randomize();
    }

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

    private void Randomize()
    {
        randomArrayValue = UnityEngine.Random.Range(0, 3);
        answerSocial.text = possiblePlanets[randomArrayValue];

        answerStudent.text = UnityEngine.Random.Range(1000, 4000).ToString();
        answerWage.text = UnityEngine.Random.Range(12000, 60000).ToString();
        answerWork.text = UnityEngine.Random.Range(800, 1500).ToString();
    }

    private void MakeArrays()
    {
        possibleSpecies[0] = "Space Centaur";
        possibleSpecies[1] = "Twi'lek";
        possibleSpecies[2] = "Ygrlllvkar";

        possiblePlanets[0] = "Planet Volton";
        possiblePlanets[1] = "Planet Ryloth";
        possiblePlanets[2] = "Planet Whoopsie";
    }

    private void ComputeWin()
    {
        if (!completedSocial) 
        {
            ExecuteWrong();
            return; 
        }
        if (!completedIncome) 
        {
            ExecuteWrong();
            return; 
        }
        if (!completedStudent) 
        {
            ExecuteWrong();
            return; 
        }
        if (!completedWork) 
        {
            ExecuteWrong();
            return; 
        }
        if (!completedMaritalStatus) 
        {
            ExecuteWrong();
            return; 
        }
        if (!completedEntity) 
        {
            ExecuteWrong();
            return;
        }
        if (!completedBirthdate) 
        {
            ExecuteWrong();
            return; 
        }
        if (!completedSpecies)
        {
            ExecuteWrong();
            return;
        }
        else
        {
            ExecuteRight();
        }
    }

    private void ExecuteRight()
    {
        submitButton.gameObject.SetActive(false);
        Destroy(submitButton);
        finalSignature.gameObject.SetActive(true);
        audioPlayer.PlayRightClip();
    }

    private void ExecuteWrong()
    {
        audioPlayer.PlayWrongClip();
        submitButton.GetComponent<ShakeTransform>().StartButtonShake();
        return;
    }

    private void CheckSocialText()
    {
        if (textFieldSocial.text.ToUpper() == answerSocial.text.ToUpper())
        {
            completedSocial = true;
            Debug.Log("completedSocial: True");
        }
        else if (textFieldSocial.text.ToUpper() == "VOLTON" && randomArrayValue == 0)
        {
            completedSocial = true;
            Debug.Log("completedSocial: True (NO PLANET TEXT)");
        }
        else if (textFieldSocial.text.ToUpper() == "RYLOTH" && randomArrayValue == 1)
        {
            completedSocial = true;
            Debug.Log("completedSocial: True (NO PLANET TEXT)");
        }
        else if (textFieldSocial.text.ToUpper() == "WHOOPSIE" && randomArrayValue == 2)
        {
            completedSocial = true;
            Debug.Log("completedSocial: True (NO PLANET TEXT)");
        }
        else
        {
            completedSocial = false;
            Debug.Log("completedSocial: False");
        }

    }

    private void CheckIncomeText()
    {
        if (textFieldIncome.text == answerWage.text)
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
        if (textFieldStudent.text == answerStudent.text)
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
        if (textFieldWork.text == answerWork.text)
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
            if (toggleGroupMaritalStatus.GetFirstActiveToggle().ToString() == "Married (UnityEngine.UI.Toggle)")
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
