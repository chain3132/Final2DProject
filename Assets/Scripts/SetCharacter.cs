using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacter : MonoBehaviour
{
    [SerializeField]private Sprite[] spritePets;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        switch (GameManager.instance.selectedPet)
        {
            case GameManager.PetType.Dragon:
                spriteRenderer.sprite = spritePets[0];
                animator.SetTrigger("DragonWalk");
                
                break;
            case GameManager.PetType.Unicon:
                spriteRenderer.sprite = spritePets[1];
                animator.SetTrigger("UniconWalk");
                break;
            case GameManager.PetType.Griffon:
                spriteRenderer.sprite = spritePets[2];
                animator.SetTrigger("GriffonWalk");
                break;
        }
    }

    
}
