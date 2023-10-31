using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseWinner;
    [SerializeField] private GameObject quitMenu;
    
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelDerrota;
    [SerializeField] private GameObject panelVictoria;
    public GameObject[] Winner;
    public GameObject[] Looser;
    public PlumasManager plumasManager;
    public string mayorName;
    public string menorName;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        string scene = SceneManager.GetActiveScene().name;

        if (scene == "Plumas"){
            int cantidadPlumasWhite = plumasManager.PlumasTotalesWhiteDuck;
            int cantidadPlumasBlack = plumasManager.PlumasTotalesBlackDuck;
            if(cantidadPlumasBlack == 5 || cantidadPlumasWhite == 5){
                if (plumasManager.PlumasTotalesWhiteDuck < plumasManager.PlumasTotalesBlackDuck){
                    mayorName = "BlackDuck";
                    menorName = "WhiteDuck";
                }
                else{
                    mayorName = "WhiteDuck";
                    menorName = "BlackDuck";
                }
                StatusWinnerPlumas(mayorName, menorName);    
            }
        
        }
    }

    //Detener tiempo del juego
    public void Pause()
    {
        try{
          Time.timeScale = 0f;
            isPaused = true;
            pauseButton.SetActive(false);
            pauseMenu.SetActive(true);  
        }
        finally{

        }
    }

    //Reanudar jugada
    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    //reiniciar juego
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //cerrar juego 

    public void Quit()
    {
        quitMenu.SetActive(true);
        panelMenu.SetActive(false);
    }

    //volver a menu de pausa
    public void ReturnMenuPause()
    {
        quitMenu.SetActive(false);
        panelMenu.SetActive(true);
    }
    public void QuitPlay()
    {
        //salir de la partida
            SceneManager.LoadScene("menu");
    
    }

    public void QuitGame()
    {
        //salir del juego
        Debug.Log("Closing game");
        Application.Quit();
    }

    public void StatusWinnerPlumas(string mayor, string menor){
        Time.timeScale = 0f;
        pauseWinner.SetActive(true);
        if (mayor == "WhiteDuck"){
            Winner[0].SetActive(true);
            Looser[1].SetActive(true);
        }
        else if (mayor == "BlackDuck"){
            Winner[1].SetActive(true);
            Looser[0].SetActive(true);
        }
    }
    public void StatusWinnerVidas(string ganador){
        Time.timeScale = 0f;
        pauseWinner.SetActive(true);
        if (ganador == "WhiteDuck"){
            Winner[0].SetActive(true);
        }
        else if (ganador == "BlackDuck"){
            Winner[1].SetActive(true);
        }
    }

    public void StatusWinner(){
        Time.timeScale = 0f;
        pauseWinner.SetActive(true);
    }
    public void Victoria(){
        Time.timeScale = 0f;
        panelVictoria.SetActive(true);
    }
    public void Derrota(){
        Time.timeScale = 0f;
        panelDerrota.SetActive(true);
    }
}
