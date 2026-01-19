using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HintUpdateScript : MonoBehaviour
{
    string hint;

    public GameObject hintTitle;
    
    [TextArea]
    public List<string> hintList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/MonoBehaviour.OnEnable.html
    void OnEnable()
    {
       hintTitle.SetActive(true);
    }

    //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/MonoBehaviour.OnDisable.html
    void OnDisable()
    {
        hintTitle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //https://docs.unity3d.com/ScriptReference/Component.GetComponentInChildren.html
        Text txt = GetComponentInChildren<Text>(true);
        txt.text = hint;
    }

    
}
