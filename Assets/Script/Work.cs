using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Work : MonoBehaviour
{
    private Lite lite;
    private InputField input;
    // Start is called before the first frame update
    void Start()
    {
        input = gameObject.transform.Find("Input").GetComponent<InputField>();
        lite = Lite.getIns();
        gameObject.transform.Find("Add").GetComponent<Button>().onClick.AddListener(() =>
        {
            lite.getAll();
        });
        gameObject.transform.Find("Insert").GetComponent<Button>().onClick.AddListener(() =>
        {
            var text = input.text;
            if (text.Length> 0)
            {
                lite.insert(text);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        lite.close();
    }
}
