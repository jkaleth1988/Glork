using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class resetbuttonscript : MonoBehaviour
{
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GameObject.Find("ResetButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(Reload);
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
