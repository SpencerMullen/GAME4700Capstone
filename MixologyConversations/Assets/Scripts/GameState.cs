using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    WAIT_FOR_CUSTOMER, // Shop is empty - waiting for a customer
    WAIT_FOR_CLICK, // At least one customer is in the shop, waiting for player to click on them
    IN_ORDER_DIALOGUE, // Player is currently engaged in the customer's order dialogue
    WAIT_FOR_MIXING_TABLE, // Order Dialogue
    IN_MIXING_TABLE, // Player is in the mixing table
    SERVING_DRINK, // Player has clicked the 'serve' button
    POST_SERVE_DIALOGUE, // Player is in dialogue with character after an order has been served
    DAY_END // Shop is closed, day is over
}
