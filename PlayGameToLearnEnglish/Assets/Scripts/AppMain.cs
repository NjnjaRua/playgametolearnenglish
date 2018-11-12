using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AppMain : MonoBehaviour {
    PopupManager puManager;

    private void Start()
    {
        if (puManager == null)
            puManager = PopupManager.getInstance();
        puManager.OnShowPopupMainMenu();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Press ESCAPE");
            if (puManager == null)
                puManager = PopupManager.getInstance();
            if (puManager != null)
            {
                if(puManager.GetQuizMainPopup() != null && puManager.GetQuizMainPopup().IsOnScreen())
                {
                    Debug.Log("quizMain");
                    puManager.OnHideQuizMainForBackKey();
                }
                else if(puManager.GetCategoriesQuiz() != null && puManager.GetCategoriesQuiz().IsOnScreen())
                {
                    Debug.Log("categoriesQuiz");
                    puManager.OnHidePopupCategoriesQuizForBackKey();
                }
            }
        }
    }
}
