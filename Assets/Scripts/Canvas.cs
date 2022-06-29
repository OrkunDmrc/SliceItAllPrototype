using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Canvas : MonoBehaviour
{
    Text levelText, pointText, levelPointText;
    Image blackImage;
    Button nextLevelButton, tryAgainButton;

    void Awake(){
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        pointText = GameObject.Find("PointText").GetComponent<Text>();
        levelPointText = GameObject.Find("LevelPointText").GetComponent<Text>();
        blackImage = GameObject.Find("BlackImage").GetComponent<Image>();
        nextLevelButton = GameObject.Find("NextLevelButton").GetComponent<Button>();
        tryAgainButton = GameObject.Find("TryAgainButton2").GetComponent<Button>();
        SetPasiveNextLevelButton();
        SetPasiveTryAgainButton();
        SetPasiveBlackImage();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLevelText(int level){
        levelText.text = "level " + level;
    }

    public void UpdatePointText(int point){
        pointText.text = "x" + point;
    }

    public void UpdateLevelPointText(int levelPoint){
        levelPointText.text = "x" + levelPoint;
    }

    public void SetActiveNextLevelButton(){
        nextLevelButton.gameObject.SetActive(true);
    }

    public void SetPasiveNextLevelButton(){
        nextLevelButton.gameObject.SetActive(false);
    }

    public void SetActiveTryAgainButton(){
        tryAgainButton.gameObject.SetActive(true);
    }

    public void SetPasiveTryAgainButton(){
        tryAgainButton.gameObject.SetActive(false);
    }

    public void SetActiveBlackImage(){
        blackImage.gameObject.SetActive(true);
    }

    public void SetPasiveBlackImage(){
        blackImage.gameObject.SetActive(false);
    }


}
