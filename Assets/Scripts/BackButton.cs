using UnityEngine;

//yleinen back-nappi, jossa on valittava toiminto: mene etusivulle tai haluttulle sivulle, sivun voi määrittää Unityn puolella
public class BackButton : MonoBehaviour 
{
    public enum BackMode //määritellään miten nappi käyttäytyy
    {
        GoHome, //mene aina etusivulle
        GoBack //mene edelliselle sivulle
    }

    public enum TargetPage
    {
        Login,
        Home
    }

    //viittaus PageManageriin
    [SerializeField] private PageManager pageManager; 
    [SerializeField] private BackMode backMode; //valitaan Inspectorissa toiminto
    [SerializeField] private TargetPage targetPage;

    private void OnMouseDown() //kun spriteä klikataan
    {
        if (pageManager == null) //tarkistetaan että PageManager on asetettu
        {
            Debug.LogWarning("PageManager puuttuu: " + gameObject.name);
            return;
        }

        ExecuteBackAction();
    }

    private void ExecuteBackAction()
    {
        switch (backMode) //katsotaan mikä moodi on valittu
        {
            case BackMode.GoHome: //jos valittu "GoHome"
                pageManager.ShowHome(); //mennään etusivulle
                break;

            case BackMode.GoBack: //valittu "GoBack"
                OpenTargetPage();
                break;
        }
    }

    private void OpenTargetPage()
    {
        switch (targetPage)
        {
            case TargetPage.Login:
                pageManager.ShowLoginScreen();
                break;

            case TargetPage.Home:
                pageManager.ShowHome();
                break;
        }
    }
}