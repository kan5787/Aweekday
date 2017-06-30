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

    public UISlider slider;
    // Use this for initialization
    public GameGrade grade = GameGrade.NORMAL;

    public TweenPosition optionPanelTween;
    public AudioSource bgm;
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnVolumeChanged()
    {
        bgm.volume = UIProgressBar.current.value;
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
