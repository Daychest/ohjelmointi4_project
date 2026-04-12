using UnityEngine;

public class PageNavigationButton : MonoBehaviour //hoitaa sivunavigoinnin sprite-napeille
{
    public enum TargetPage //määritellään kaikki sivut joihin voidaan navigoida.
    {
        QR,
        News,
        FriendProfile,
        WorkoutDetail,
        VisitHistory,
        Payments
    }

    [Header("Viittaukset")]
    [SerializeField] private PageManager pageManager;

    [Header("Asetukset")]
    [SerializeField] private TargetPage targetPage; //määrittää mikä sivu avataan.

    private void OnMouseDown() //ajetaan kun käyttäjä klikkaa spriteä
    {
        if (pageManager == null) //tarkistetaan että PageManager ei ole null
        {
            Debug.LogWarning("PageManager puuttuu objektista: " + gameObject.name); //oma debug
            return;
        }

        OpenSelectedPage(); //hoidetaan sivun avaus
    }

    //metodi hoitaa sivun valinnan ja avauksen
    private void OpenSelectedPage()
    {
        switch (targetPage) //tarkistetaan mikä sivu on valittuna
        {
            case TargetPage.QR:
                pageManager.ShowQR();
                break;

            case TargetPage.News:
                pageManager.ShowNews();
                break;

            case TargetPage.FriendProfile:
                pageManager.ShowFriendProfile();
                break;

            case TargetPage.WorkoutDetail:
                pageManager.ShowWorkoutDetail();
                break;

            case TargetPage.VisitHistory:
                pageManager.ShowVisitHistory();
                break;

            case TargetPage.Payments:
                pageManager.ShowPayments();
                break;
        }
    }
}