using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatManager : MonoBehaviour
{
    public static StatManager instance;
    private int stars = 0;
    [SerializeField] private TextMeshProUGUI starText;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        starText.text = "" + stars;
    }

    public void AddStars(int amount)
    {
        stars += amount;
        starText.text = "" + stars;
    }

    public void RemoveStars(int amount)
    {
        stars -= amount;
        starText.text = "" + stars;
    }

    public int GetStars()
    {
        return stars;
    }
}
