using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO : build custom editor for flavors and effects; maybe have a parent 'features' class they inherit from so that it can be used for both?
public class Flavor
{
    public Flavor(string _name, Flavors _category, int _strength)
    {
        name = _name;
        category = _category;
        strength = _strength;
    }

    public string name { get; }
    public Flavors category { get; }
    // Should be a variable between 1 and 3 for weak, med, strong
    public int strength { get; }
}

public enum Flavors
{
    RED,
    GREEN,
    BLUE
}