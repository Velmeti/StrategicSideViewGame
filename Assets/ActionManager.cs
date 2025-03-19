using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionManager : MonoBehaviour
{
    [SerializeField] private int _actionNumber;
    private int _actionRemaining;

    [SerializeField] private TextMeshProUGUI _actionRemainingText;


    void Start()
    {
        ResetAction();
        ChangeActionRemaigningText();
    }


    void Update()
    {
        
    }


    public void ResetAction()
    {
        _actionRemaining = _actionNumber;
        ChangeActionRemaigningText();
    }


    public void DecreaseAction()
    {
        _actionRemaining--;
        ChangeActionRemaigningText();
    }


    private void ChangeActionRemaigningText()
    {
        _actionRemainingText.text = "Actions Restantes : " + _actionRemaining; 
    }


    public bool CanDoAction()
    {
        if (_actionRemaining <= 0)
        {
            return false;
        }
        return true;
    }
}
