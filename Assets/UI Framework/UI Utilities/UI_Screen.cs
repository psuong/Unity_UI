﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// UI_Screen contains dictionaries which keeps
/// references to all Text, Slider, Image
/// </summary>
public class UI_Screen : MonoBehaviour {

    protected Dictionary<string, Text> textDict;
    protected Dictionary<string, Image> imageDict;
    protected Dictionary<string, Slider> sliderDict;

    /// <summary>
    /// Unity's Start() method; this checks to see if
    /// the dictionaries are built up, if not then it builds up the
    /// dictionaries.
    /// </summary>
	protected virtual void Start () {
	    if (textDict == null || imageDict == null || sliderDict == null) {
            SetUp();
        }
    }

    /// <summary>
    /// Populates the dictionaries with references
    /// to all Text, Image, and Slider components within
    /// the scene.
    /// </summary>
    public void SetUp() {
        textDict = new Dictionary<string, Text>();
        imageDict = new Dictionary<string, Image>();
        sliderDict = new Dictionary<string, Slider>();

        Text[] textElements = GetComponentsInChildren<Text>(true);
        Image[] imageElements = GetComponentsInChildren<Image>(true);
        Slider[] sliderElements = GetComponentsInChildren<Slider>(true);

        for (int i = 0; i < textElements.Length; i++) {
            // Ignore text elements if the parent object has a component of type Button
            if (textElements[i].transform.parent.GetComponent<Button>() == null)
                textDict.Add(textElements[i].name, textElements[i]);
        }

        for (int i = 0; i < imageElements.Length; i++) {
            imageDict.Add(imageElements[i].name, imageElements[i]);
        }

        for (int i = 0; i < sliderElements.Length; i++) {
            sliderDict.Add(sliderElements[i].name, sliderElements[i]);
        }
    }

    #region Open and Close Screen
    /// <summary>
    /// Activates the instance of a gameObject 
    /// that UI_Screen is attached to.
    /// </summary>
    public void OpenThisScreen() { gameObject.SetActive(true); }

    /// <summary>
    /// Deactivates the instance of a gameObject
    /// that UI_Screen is attached to.
    /// </summary>
    public void CloseThisScreen() { gameObject.SetActive(false); }
    #endregion

    /// <summary>
    /// Can set the fill of the image in the screen. Value from 0-1
    /// </summary>
    /// <param name="imageName"></param>
    /// <param name="fillValue"></param>
    public void SetImageFill(string imageName, float fillValue) {
        if (imageDict.ContainsKey(imageName)) {
            imageDict[imageName].fillAmount = fillValue;
        }
        else {
            Debug.LogError("Image not in dictionary");
        }
    }

    /// <summary>
    /// Can set the fill of the Slider. Value from 0-1
    /// </summary>
    /// <param name="sliderName"></param>
    /// <param name="sliderValue"></param>
    public void SetSliderFill(string sliderName, float sliderValue)
    {
        if (sliderDict.ContainsKey(sliderName)){
            sliderDict[sliderName].value = sliderValue;
        } 
        else { 
            Debug.LogError("Slider name not in dictionary");
        }
    }

    #region UI Getters

    #endregion
}
