using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1, point = 0, levelPoint = 0;
    public Transform knife, pointPowers, background;

    void Awake(){
        //reset
        if(false){
            PlayerPrefs.SetInt("point", 0);
            PlayerPrefs.SetInt("level", 1);
        }

        if(PlayerPrefs.GetInt("point") == null || PlayerPrefs.GetInt("level") == null){
            PlayerPrefs.SetInt("point", point);
            PlayerPrefs.SetInt("level", level);
        }else{
            point = PlayerPrefs.GetInt("point");
            level = PlayerPrefs.GetInt("level");
            if(level == 0){
                level = 1;
            }
        }

        switch(level){
            case 1:
                knife.position = new Vector3(0, knife.position.y, knife.position.z);
                pointPowers.position = new Vector3(21, pointPowers.position.y, pointPowers.position.z);
                background.position = new Vector3(-3.5f, background.position.y, background.position.z);
            break;
            case 2:
                knife.position = new Vector3(-50, knife.position.y, knife.position.z);
                pointPowers.position = new Vector3(-30, pointPowers.position.y, pointPowers.position.z);
                background.position = new Vector3(-40, background.position.y, background.position.z);
            break;
            case 3:
                
                knife.position = new Vector3(-100, knife.position.y, knife.position.z);
                pointPowers.position = new Vector3(-80, pointPowers.position.y, pointPowers.position.z);
                background.position = new Vector3(-125, background.position.y, background.position.z);
            break;
        }
        Camera.main.transform.position = new Vector3(knife.position.x -3, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().UpdateLevelText(level);
        GetComponent<Canvas>().UpdatePointText(point);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(){
        GetComponent<Canvas>().SetActiveTryAgainButton();
        GetComponent<Canvas>().SetActiveBlackImage();
        PlayerPrefs.SetInt("point", point);
        Debug.Log("game Over");
    }

    public void LevelUp(int coefficient){
        if(level < 3){
            level++;
        }else{
            level = 1;
        }
        levelPoint = coefficient * levelPoint;
        GetComponent<Canvas>().UpdateLevelPointText(levelPoint);
        point += levelPoint;
        GetComponent<Canvas>().UpdatePointText(point);
    }

    public void LoadLevel(){
        PlayerPrefs.SetInt("point", point);
        PlayerPrefs.SetInt("level", level);
        Application.LoadLevel(0);
    }

    public void AddPoint(){
        point++;
        levelPoint++;
        GetComponent<Canvas>().UpdatePointText(point);
    }
}
