using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizMain : BasePopup {
    [SerializeField]
    private Text score;

    [SerializeField]
    private GridLayoutGroup gridImages;

    [SerializeField]
    private GridLayoutGroup gridResults;

    [SerializeField]
    private GridLayoutGroup gridLetters;

    [SerializeField]
    private GameObject gObjNext;

    PopupManager puManager;
    
    // Use this for initialization
    void Start () {
        puManager = PopupManager.getInstance();

    }

    public void OnShowPopup()
    {
        ShowPopup();
    }

    public void OnHidePopup()
    {
        HidePopup();
    }

    public void OnBack()
    {
        //back Categories quiz
        if (puManager == null)
            return;
        OnHidePopup();
        puManager.OnShowPopupCategoriesQuiz();
    }

    public void OnOpenLetter()
    {
        //open 1 letter by coin
    }

    public void OnShare()
    {
        //share
    }

    public void OnRemove()
    {
        //remove 1 letter
    }

    public void OnSkip()
    {
        //skip this level
    }

    public void OnBuyCoin()
    {
        //buy coin
    }
}
