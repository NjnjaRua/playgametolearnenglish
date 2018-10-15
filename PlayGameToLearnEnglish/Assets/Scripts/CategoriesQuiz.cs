using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoriesQuiz : BasePopup {
    PopupManager puManager;

	// Use this for initialization
	void Start () {
        puManager = PopupManager.getInstance();
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
