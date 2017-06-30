using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bottonClicked : MonoBehaviour {
    public GameObject setting;
    public GameObject volume;
    private int setclickcount=0;
    private int volclickcount=0;

    public UISlider slider;
    public AudioSource bgm;
    // Use this for initialization
    void Start () {
        setting.SetActive(false);
        volume.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnVolumeChanged()
    {
        bgm.volume = UIProgressBar.current.value;
    }

    public void OnsettingClick()
    {
        setclickcount++;
        if (setclickcount % 2 == 1)
        {
            setting.SetActive(true);
        }
        else
        {
            setting.SetActive(false);
        }
    }

    public void OnvolumeClick()
    {
        volclickcount++;
        if (volclickcount % 2 == 1)
        {
            volume.SetActive(true);
        }
        else
        {
            volume.SetActive(false);
        }
    }

    public void OnHomeButtonClick()
    {
        SceneManager.LoadScene("homeScreen");
    }

    public void OnHomeRetryClick()
    {
        SceneManager.LoadScene("Level1");
    }
}
