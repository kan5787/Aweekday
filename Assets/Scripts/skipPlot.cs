using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipPlot : MonoBehaviour {

    public void OnSkipClick()
    {
        SceneManager.LoadScene("Level1");
    }
}
