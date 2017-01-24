using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {

    public int id;
	void Update ()
    {
        start_scene(id);
	}

    public void start_scene(int id)
    {
        SceneManager.LoadScene(id);
    }
}
