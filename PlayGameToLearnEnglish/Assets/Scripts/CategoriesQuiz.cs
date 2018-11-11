using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoriesQuiz : BasePopup {
    PopupManager puManager;

    [SerializeField]
    private GridLayoutGroup gridCategoriesQuiz;

    [SerializeField]
    private GameObject categoriesQuizItemPrefab;

    // Use this for initialization
    void Start() {
        puManager = PopupManager.getInstance();
        
    }

    private void OnEnable()
    {
        OnUpdateCategoriesQuiz();
    }

    void OnUpdateCategoriesQuiz()
    {
        if (gridCategoriesQuiz == null || categoriesQuizItemPrefab ==  null)// || listCategoriesIcon == null || listCategoriesName == null)
            return;
        int i = 0, lenChild = gridCategoriesQuiz.transform.childCount;
        for (i = 0; i < lenChild; i++)
            gridCategoriesQuiz.transform.GetChild(i).gameObject.SetActive(false);
        GameObject gObj;
        for (i = 0; i < ConstantManager.MAX_CATEGORIES_QUIZ; i++)
        {
            gObj = null;
            if (i < lenChild)
                gObj = gridCategoriesQuiz.transform.GetChild(i).gameObject;
            if (gObj == null)
            {
                gObj = Instantiate(categoriesQuizItemPrefab, Vector3.one, Quaternion.identity, gridCategoriesQuiz.transform) as GameObject;
                gObj.transform.localScale = Vector3.one;
            }
            gObj.SetActive(true);
            CategoriesQuizItem categoriesQuizItem = gObj.GetComponent<CategoriesQuizItem>();
            if(categoriesQuizItem != null)
            {
                //todo
                categoriesQuizItem.OnUpdateData((ConstantManager.CATEGORY_IDS)i);
            }
        }
    }

    public void OnShowPopup()
    {
        base.ShowPopup();
    }

    public void OnHidePopup()
    {
        base.HidePopup();
    }
}
