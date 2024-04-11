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

    // Update is called once per frame
    void Update()
    {

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
}
