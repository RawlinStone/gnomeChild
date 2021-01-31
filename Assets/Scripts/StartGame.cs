using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(ChangeScene);
    }

    // Update is called once per frame
    void ChangeScene()
    {
        Application.LoadLevel("_mainHub");
    }
}
