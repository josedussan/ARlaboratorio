using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transicionTemporal : MonoBehaviour
{
    [SerializeField]
    private float transitionTime;
    private Animator transitionAnimator;
    private string AnteriorPrefName="anterior",actual,anterior;
    // Start is called before the first frame update
    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
        Debug.Log("anterior: " + anterior);
        Debug.Log("actual: " + actual);

    }

    private void Awake()
    {
        actual = SceneManager.GetActiveScene().name;
        loadData();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void saveData() {
        PlayerPrefs.SetString(AnteriorPrefName,anterior);
    }

    private void loadData() {
        anterior = PlayerPrefs.GetString(AnteriorPrefName,"none");
    }

    public void cargarEscena(string escena) {
        StartCoroutine(sceneLoad(escena));
    }
    public void cargarEscenaPredefinida()
    {
        StartCoroutine(sceneLoad(anterior));
    }

    public IEnumerator sceneLoad(string escena) {
        anterior = SceneManager.GetActiveScene().name;
        Debug.Log(anterior);
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(escena);
        saveData();
    }

    public void cerrar() {
        PlayerPrefs.SetString(AnteriorPrefName, "none");
        Application.Quit();
    }

    private void OnDestroy()
    {
        saveData();
    }
}
