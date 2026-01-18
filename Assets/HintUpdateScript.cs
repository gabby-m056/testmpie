using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HintUpdateScript : MonoBehaviour
{
    string hint;

    [TextArea]
    public List<string> hintList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //https://docs.unity3d.com/ScriptReference/Component.GetComponentInChildren.html
        Text txt = GetComponentInChildren<Text>(true);
        txt.text = hint;
    }
}
