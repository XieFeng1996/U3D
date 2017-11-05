using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("01");
    }
}
