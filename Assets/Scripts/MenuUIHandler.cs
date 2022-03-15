using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : UIHandler
{
    public TMP_InputField inputField;
    public TMP_Text bestScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.Instance.ScoreList.Count != 0 )
        {
            DataManager.Instance.UpdateBestScore(bestScoreText);
            bestScoreText.gameObject.SetActive(true);
        }

        inputField.text = DataManager.Instance.CurrentPlayer;
    }


// Load main scene
public void StartNew()
{
    DataManager.Instance.CurrentPlayer = inputField.text == "" ? "Noname" : inputField.text;
    SceneManager.LoadScene(2);

}

public void Exit()
{
#if UNITY_EDITOR
    EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
}

}
