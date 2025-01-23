using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transicionTemporal : MonoBehaviour
{
    [SerializeField]
    private float transitionTime;
    private Animator transitionAnimator;
    private string AnteriorPrefName="anterior",current,previous;
    // Start is called before the first frame update
    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
        Debug.Log("anterior: " + previous);
        Debug.Log("actual: " + current);

    }

    private void Awake()
    {
        current = SceneManager.GetActiveScene().name;
        LoadData();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void SaveData() {
        PlayerPrefs.SetString(AnteriorPrefName,previous);
    }

    private void LoadData() {
        previous = PlayerPrefs.GetString(AnteriorPrefName,"none");
    }

    public void LoadScene(string scene) {
        StartCoroutine(SceneLoad(scene));
    }
    public void LoadPredefinedScene()
    {
        StartCoroutine(SceneLoad(previous));
    }

    public IEnumerator SceneLoad(string escena) {
        previous = SceneManager.GetActiveScene().name;
        Debug.Log(previous);
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(escena);
        SaveData();
    }

    public void Close() {
        PlayerPrefs.SetString(AnteriorPrefName, "none");
        Application.Quit();
    }

    private void OnDestroy()
    {
        SaveData();
    }
}
