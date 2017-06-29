using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameGrade
{
    EASY,
    NORMAL,
    DIFFCULTY
}

public class gamesetting : MonoBehaviour {

    // Use this for initialization
    public float volume = 1;
    public GameGrade grade = GameGrade.NORMAL;

    public TweenPosition optionPanelTween;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnVolumeChanged()
    {
        print("dd");
        volume = UIProgressBar.current.value;//获取当前操作值
    }
    public void OnGameGradeChanged()
    {
        switch (UIPopupList.current.value)
        {
            case "简单":
                grade = GameGrade.EASY;
                break;
            case "一般":
                grade = GameGrade.NORMAL;
                break;
            case "困难":
                grade = GameGrade.DIFFCULTY;
                break;
        }

    }
    public void OnOptionButtonClick()
    {
        optionPanelTween.PlayForward();
    }

    public void OnCompleteSettingButtonClick()
    {
        optionPanelTween.PlayReverse();
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("beginPlot");
    }
}
