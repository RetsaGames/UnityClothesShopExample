using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An <c>Actor</c> is a Player or an NPC 
/// </summary>
public class Actor : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private AnimationType initialAnimation;
    [SerializeField] public int coins;
    [SerializeField] public List<Item> inventory;

    [Header("References")]
    [SerializeField] private SpriteAnimations body;
    [SerializeField] private SpriteAnimations clothes;
    [SerializeField] private SpriteAnimations hat;

    void Start(){
        PlayAnimation(initialAnimation);
    }

    public void PlayAnimation(AnimationType animationType){
        body.PlayAnimation(animationType);
        if (clothes)
            clothes.PlayAnimation(animationType);
        if (hat)
            hat.PlayAnimation(animationType);
    }

    /// <summary>
    /// Updates the sorting order of the sprites based on the Y position. Objects that are in front of others should be drawn first.
    /// </summary>
    public void UpdateDepth(){
        body.UpdateDepth();
        if (clothes)
            clothes.UpdateDepth();
        if (hat)
            hat.UpdateDepth();
    }

    public void SetClothes(SpriteAnimations newClothes){
        clothes = newClothes;
    }

    public SpriteAnimations GetClothes(){
        return clothes;
    }

    public void RemoveClothes(){
        if (clothes)
            Destroy(clothes.gameObject);
    }

    public void SetHat(SpriteAnimations newHat){
        hat = newHat;
    }

    public SpriteAnimations GetHat(){
        return hat;
    }

    public void RemoveHat(){
        if (hat)
            Destroy(hat.gameObject);
    }
}
