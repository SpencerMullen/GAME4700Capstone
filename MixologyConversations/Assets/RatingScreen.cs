using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingScreen : MonoBehaviour
{
    public GameObject stars;
    public SpriteRenderer ratingStarDisplay;
    public Sprite oneStar;
    public Sprite twoStar;
    public Sprite threeStar;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.Instance.OnDrinkRating += setRatingStars;
        LevelManager.Instance.OnGameStateChange += handleGameState;
    }

    private void handleGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.RATING_SCREEN:
                stars.SetActive(true);
                break;
        }
    }

    private void setRatingStars(int rating)
    {
        switch (rating)
        {
            case 1:
                ratingStarDisplay.sprite = oneStar;
                break;
            case 2:
                ratingStarDisplay.sprite = twoStar;
                break;
            case 3:
                ratingStarDisplay.sprite = threeStar;
                break;
            default:
                ratingStarDisplay.sprite = null;
                break;
        }

        stars.SetActive(true);

    }
}
