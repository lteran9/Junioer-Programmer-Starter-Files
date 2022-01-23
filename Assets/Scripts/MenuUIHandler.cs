using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
   public ColorPicker ColorPicker;

   public void NewColorSelected(Color color)
   {
      // add code here to handle when a color is selected
      GameManager.instance.teamColor = color;
   }

   private void Start()
   {
      ColorPicker.Init();
      //this will call the NewColorSelected function when the color picker have a color button clicked.
      ColorPicker.onColorChanged += NewColorSelected;

      ColorPicker.SelectColor(GameManager.instance.teamColor);
   }

   public void StartNew()
   {
      SceneManager.LoadScene(1);
   }

   public void Exit()
   {
      GameManager.instance.SaveColor();

#if UNITY_EDITOR
      EditorApplication.ExitPlaymode();
#else
      Application.Quit(); 
#endif
   }

   public void SaveColorClicked()
   {
      GameManager.instance.SaveColor();
   }

   public void LoadColorClicked()
   {
      GameManager.instance.LoadColor();
      ColorPicker.SelectColor(GameManager.instance.teamColor);
   }
}
