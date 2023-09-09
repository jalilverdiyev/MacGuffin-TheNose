using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnPointerAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

     public Sprite animationSprite;
     public Image background;
     public Sprite nonAnimation;

     public void OnPointerEnter(PointerEventData eventData)
  {
    background.sprite = animationSprite;
  }
  public void OnPointerExit(PointerEventData eventData)
  {
    background.sprite = nonAnimation;
  }
}
