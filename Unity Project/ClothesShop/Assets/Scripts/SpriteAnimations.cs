using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>SpriteAnimations</c> plays animations & updates the sprite sorting order of an item/character.
/// </summary>
public class SpriteAnimations : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    
    private int sortOffset;

    void Start(){
        sortOffset = spriteRenderer.sortingOrder;
        UpdateDepth();
    }

    public void PlayAnimation(AnimationType animationType){
        if (animator){
            animator.Play(animationType.ToString());
        }
    }

    /// <summary>
    /// Updates the sorting order of the sprites based on the Y position. Objects that are in front of others should be drawn first.
    /// </summary>
    public void UpdateDepth(){
        spriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.y*100) + sortOffset;
    }
}
