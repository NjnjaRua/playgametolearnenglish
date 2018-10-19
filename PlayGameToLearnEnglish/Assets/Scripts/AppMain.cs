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
        /*if(Input.GetKey(KeyCode.Escape))
        {
            if (puManager == null)
                puManager = PopupManager.getInstance();
            if (puManager != null)
            {
                if(puManager.quizMain != null && puManager.quizMain.IsOnScreen())
                {
                    puManager.OnHideQuizMainForBackKey();
                }
                else if(puManager.categoriesQuiz != null && puManager.categoriesQuiz.IsOnScreen())
                {
                    puManager.OnHidePopupCategoriesQuizForBackKey();
                }
            }
        }*/
    }
}
