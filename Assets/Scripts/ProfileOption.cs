using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileOption : MonoBehaviour
{
    [SerializeField] private Image image;
    public void ModifyImage(Sprite sprite) => image.sprite = sprite;
}
