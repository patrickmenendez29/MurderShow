using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using Json;

public class GameLoader : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(delegate {
            if (this.gameObject.name == "start")
            {
                SceneManager.LoadScene("difficulty", LoadSceneMode.Single);
                

            } else if (this.gameObject.name == "continue")
            {



            } else
            {



            }
	

	    });
    }

}
