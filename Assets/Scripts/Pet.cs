using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pet 
{
    private string _petName = "Pet"; // set default name
    public string PetName { get => _petName; set => _petName = value; }
    private int _age;
    public int Age { get => _age; set => _age = value;}
    private float _hungerLevel;
    public float HungerLevel{ get => _hungerLevel; set => _hungerLevel = value; }
    private int _happinessLevel;
    public int HappinessLevel{ get => _happinessLevel; set => _happinessLevel = value; }
    private float _thirstLevel;
    public float ThirstLevel{ get => _thirstLevel; set => _thirstLevel = value; }

    public float CurrentHunger
    {
        get => _currentHunger;
        set
        {
            _currentHunger = value;
            if (_currentHunger >= HungerLevel)
            {
                _currentHunger = HungerLevel;
            }
        }
    }

    private float _currentHunger;
    public float CurrentThirst{ get => _currentThirst;
        set { 
            _currentThirst = value;
            if (_currentThirst >= ThirstLevel)
            {
                _currentThirst = ThirstLevel;
            }
        } 
    }
    
    private float _currentThirst;
    public float CurrentHappiness{ get => _currentHappiness;
        set
        {
            _currentHappiness = value;
            if (_currentHappiness >= HappinessLevel)
            {
                _currentHappiness = HappinessLevel;
            }
        }
    } 

    
    private float _currentHappiness;
    public float HungerDepletionRate = 0.5f;
    public float ThirstDepletionRate = 0.4f;
    public float HappinessDepletionRate = 0.05f;

    public void Init(string petname, int age, float hunger, int happiness, float thirst)
    {
        _petName = petname;
        _age = age;
        _hungerLevel = hunger;
        _happinessLevel = happiness;
        _thirstLevel = thirst;
        _currentHunger = _hungerLevel;
        _currentThirst = _thirstLevel;
        _currentHappiness = _happinessLevel;
    }
    
    // Behaviour
    public abstract void Eat();
    public abstract void Drink();
    public virtual void  Clean() {
        Debug.Log("The pet is playing.");
    }

    public bool IsDead() {
        if (CurrentHunger <= 0 || CurrentThirst <= 0 || CurrentHappiness <= 0)
        {
            return true;
        }

        return false;
    }
}
