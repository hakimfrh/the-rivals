using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject volumePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created    public void restartGame(){
    public void playGame(){
        SceneManager.LoadScene("Map_1");
    }
    public void exitGame(){
        Application.Quit();
    }

    public void openVolumePanel(){
        menuPanel.SetActive(false);
        volumePanel.SetActive(true);
    }
    public void openMenuPanel(){
        menuPanel.SetActive(true);
        volumePanel.SetActive(false);
    }



}
