using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOffDamage : MonoBehaviour
{
    public Button button;
    public Button button2;
    public bool Invincibility;
    // Start is called before the first frame update
    void Start()
    {
        Button button = GameObject.Find("TurnOffDamage").GetComponent<Button>();
        Button button2 = GameObject.Find("TurnOnDamage").GetComponent<Button>();
        Invincibility = false;
    }

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(DisableDamage);
        button2.onClick.AddListener(EnableDamage);
    }

    void DisableDamage()
    {
        Invincibility = true;
        Debug.Log("Damage Off");
    }

    void EnableDamage()
    {
        Invincibility = false;
        Debug.Log("Damage On");
    }

}
