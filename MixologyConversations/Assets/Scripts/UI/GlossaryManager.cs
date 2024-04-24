using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryManager : MonoBehaviour
{
    public GameObject BookMenu;
    public GameObject CurrentMenu;
    public GameObject GlossaryButton;
    private bool menuActivated;   
    public Image bookImage;

    // Start is called before the first frame update
    void Start()
    {
        menuActivated = false;
        bookImage = this.gameObject.GetComponent<Image>();
    }

    public void handleBookMenu()
    {
        // Book Menu doesn't exists
        if (BookMenu == null)
        {
            Debug.Log("Book Menu Null");
            return;
        }

        // Handles Opening Menu
        if (!menuActivated)
        {
            Time.timeScale = 0;
            BookMenu.SetActive(true);
            menuActivated = true;
            var tempColor = bookImage.color;
            tempColor.a = 1f;
            bookImage.color = tempColor;
            return;
        }

        // Handles Closing Menu
        if (CurrentMenu == null)
        {
            Time.timeScale = 1;
            BookMenu.SetActive(false);
            menuActivated = false;
            var tempColor = bookImage.color;
            tempColor.a = 0f;
            bookImage.color = tempColor;
            return;
        }

        // Handles Closing Ingredient or Recipe Menu
        if (menuActivated)
        {
            CurrentMenu.SetActive(false);
            CurrentMenu = null;
            BookMenu.SetActive(true);
            return;
        }
    }

    public void OpenIngredientMenu()
    {
        if (menuActivated) 
        {
            CurrentMenu = transform.Find("IngredientMenu").gameObject;
            BookMenu.SetActive(false);
            CurrentMenu.SetActive(true);
        }
    }

    public void OpenRecipeMenu()
    {
        if (menuActivated) 
        {
            CurrentMenu = transform.Find("RecipeMenu").gameObject;
            BookMenu.SetActive(false);
            CurrentMenu.SetActive(true);
        }
    }
}
