using UnityEngine;
using UnityEngine.SceneManagement;

public class PlumasManager : MonoBehaviour
{   
    public static PlumasManager Instance { get; private set; }

    public int PlumasTotalesWhiteDuck { get { return plumasTotalesWhiteDuck; } }
    private int plumasTotalesWhiteDuck;

    public int PlumasTotalesBlackDuck { get { return plumasTotalesBlackDuck; } }
    private int plumasTotalesBlackDuck;
    public string TagPlayer { get { return tagPlayer;} }
    private string tagPlayer;
    private int vidasWhite = 3;
    private int vidasBlack = 3;
    public HUD hud;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPlumas(int plumasASumar, string tag)
    {
        if (tag == "WhiteDuck")
        {
            plumasTotalesWhiteDuck += plumasASumar;
            hud.ActualizarPlumasWhite(plumasTotalesWhiteDuck);
        }
        else if (tag == "BlackDuck")
        {
            plumasTotalesBlackDuck += plumasASumar;
            hud.ActualizarPlumasBlack(plumasTotalesBlackDuck);
        }
        tagPlayer = tag;
        Debug.Log(plumasTotalesWhiteDuck);
        Debug.Log(plumasTotalesBlackDuck);
    }

    public void PerderVidas(string tag)
    {
        if (tag == "WhiteDuck"){
            vidasWhite--;
            hud.DesactivarVidas(vidasWhite);
        }
        else if(tag == "BlackDuck"){
            vidasBlack--;
            hud.DesactivarVidasBlack(vidasBlack);
        }
    }
    public void ObtenerBaby(string tag){
        Debug.Log(tag);
        if (tag == "WhiteDuck"){
            hud.ActivarBabies(1,"WhiteDuck");
        }
        else if(tag == "BlackDuck"){
            hud.ActivarBabies(0,"BlackDuck");
        }
    }
}
