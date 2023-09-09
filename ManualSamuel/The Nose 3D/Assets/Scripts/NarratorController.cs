using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NarratorController : MonoBehaviour
{
   public List<string> narratorWords;
   public TextMeshProUGUI subtitleText;
   private int currentIndex = 0;

   private void Start()
   {
    subtitleText.text = narratorWords[currentIndex];
    currentIndex++;
   }
   public void ShowNextSubtitle()
   {
    if(currentIndex < narratorWords.Count){
        subtitleText.text = narratorWords[currentIndex];
        currentIndex++;
    }
   }
}
