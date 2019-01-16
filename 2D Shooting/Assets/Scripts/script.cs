using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{
    
    public void ChangetoScene1() {
        SceneManager.LoadScene("Mainmenu");

    }
    public void ChangetoScene2()
    {
        SceneManager.LoadScene("Tutorial");

    }
    public void ChangetoScene3()
    {
        SceneManager.LoadScene("Stage1");

    }
    public void ChangetoScene4()
    {
        SceneManager.LoadScene("Stage2");

    }

    

}
