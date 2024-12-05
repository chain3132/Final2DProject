using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Pet 
{
    void Init(string petName, int age, int hunger,int happiness, int thirst)
    {
        base.Init(petName, age, hunger, happiness,thirst );
    }
    public override void Clean()
    {
        CurrentHappiness += 2;
    }
    public override void Eat()
    {
        Debug.Log("The dragon is eating.");
        CurrentHunger += 20;
    }

    public override void Drink()
    {
        CurrentThirst += 20;
    }
}
