using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CanvasButtons : MonoBehaviour
{
    public Sprite musicOn,musicOff;
    private void Start() {
         if(PlayerPrefs.GetString("music")=="No"&& gameObject.name =="Music")
         GetComponent<Image>().sprite = musicOff;
    }
    public void RestartGame () {
        if(PlayerPrefs.GetString("music")!="No")
            GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadShop () {
        if(PlayerPrefs.GetString("music")!="No")
            GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Shop");
    }
     public void CloseShop () {
        if(PlayerPrefs.GetString("music")!="No")
            GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Main");
    }
    public void LoadYouTube(){
         if(PlayerPrefs.GetString("music")!="No")
            GetComponent<AudioSource>().Play();
        Application.OpenURL("https://www.youtube.com/channel/UCAdmYhEjJOpuFlOTmDEbuVQ");
    }
    public void MusicWork () {
        //no music, we need to turn it on
        if(PlayerPrefs.GetString("music")=="No"){
           PlayerPrefs.SetString("music","Yes");
           GetComponent<AudioSource>().Play();
           GetComponent<Image>().sprite = musicOn;
        }else{
            PlayerPrefs.SetString("music","No");
            GetComponent<Image>().sprite = musicOff;
        }
    }
}
