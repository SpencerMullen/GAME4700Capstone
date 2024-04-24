using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerIC : MonoBehaviour
{
    [SerializeField] private MixingInventoryManager mixingManager;
    [SerializeField] private ShelfManager shelfManager;
    [SerializeField] private StatManager statManager;


    // TODO: This should be replaced with the character manager but for testing purposes...
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EvaluateOrder()
    {
        Recipe currentDrink = mixingManager.currentDrink;
        

    }
}
