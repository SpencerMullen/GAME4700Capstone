using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect
{
    public Effect(Effects _category, int _strength)
    {
        category = _category;
        strength = _strength;
    }

    public Effects category { get; }
    // Should be a variable between 1 and 3 for weak, med, strong
    public int strength { get; }
}

public enum Effects
{
    ENERGY,
    FREEZING,
    COMBUSTIBLE,
    LUCKY,
    STRENGTH,
    SPEED,
    FOCUS,
    CLARITY,
    CONFIDENCE
}
