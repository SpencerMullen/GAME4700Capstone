using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossaryManager : MonoBehaviour
{
    public GameObject GlossaryMenu;
    public GameObject GlossaryButton;
    private bool menuActivated;   
    public GameObject CurrentMenu;
    // Start is called before the first frame update
    void Start()
    {
        menuActivated = false;
    }

    public void OpenMenu()
    {
        if (GlossaryMenu != null)
        {
            if (menuActivated)
            {
                Time.timeScale = 1;
                GlossaryMenu.SetActive(false);
                menuActivated = false;
            }
            else if (!menuActivated)
            {
                Time.timeScale = 0;
                GlossaryMenu.SetActive(true);
                menuActivated = true;
            }
        }
    }

    public void ChangeIngredientMenu()
    {
        if (menuActivated) 
        {
            CurrentMenu = transform.Find("IngredientMenu").gameObject;
            GlossaryMenu.SetActive(false);
            CurrentMenu.SetActive(true);
        }
    }

    public void ChangeRecipeMenu()
    {
        if (menuActivated) 
        {
            CurrentMenu = transform.Find("RecipeMenu").gameObject;
            GlossaryMenu.SetActive(false);
            CurrentMenu.SetActive(true);
        }
    }
}
