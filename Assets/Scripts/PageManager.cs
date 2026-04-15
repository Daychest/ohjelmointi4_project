using UnityEngine; //Unityn perustoiminnot

public class PageManager : MonoBehaviour //luokka, joka liitetään ruudulla olevaan elementtiin.
{
    [Header("Pääsivut")]
    [SerializeField] private GameObject homePage; //linkitetään Koti-sivu jne..
    [SerializeField] private GameObject friendsPage;
    [SerializeField] private GameObject trainingPage;
    [SerializeField] private GameObject profilePage;

    [Header("Alapalkki")]
    [SerializeField] private GameObject bottomNavigationBar;

    [Header("Login sivut")] //tekee uuden otsikon Inspectoriin alisivuja varten. objektit voi vetää siihen suoraan
    [SerializeField] private GameObject loginScreenPage;
    [SerializeField] private GameObject enterLoginCredentialsPage;
    [SerializeField] private GameObject registerAccountPage;

    [Header("Alisivut")] //tekee uuden otsikon Inspectoriin alisivuja varten. objektit voi vetää siihen suoraan
    [SerializeField] private GameObject qrPage;
    [SerializeField] private GameObject newsPage;
    [SerializeField] private GameObject friendProfilePage;
    [SerializeField] private GameObject workoutDetailPage;
    [SerializeField] private GameObject visitHistoryPage;
    [SerializeField] private GameObject paymentsPage;

    [Header("Popupit")]
    [SerializeField] private GameObject QRCodeInstructionsPopup;
    [SerializeField] private GameObject addFriendPopup;
    [SerializeField] private GameObject addWorkoutPopup;
    [SerializeField] private GameObject editWorkoutPopup;
    [SerializeField] private GameObject addExercisePopup;
    [SerializeField] private GameObject editExercisePopup;
    [SerializeField] private GameObject overlay;

    private GameObject activePage = null;
    private Vector3 activePageOffScreenPosition = new Vector3(0, 0, 0);

    private void Start() //tämä metodi ajetaan automaattisesti sovelluksen alussa
    {
        HideAllPopups();
        if (bottomNavigationBar != null) bottomNavigationBar.SetActive(false);  //piilotetaan alapalkki
        ShowLoginScreen(); //näytetään alussa Login-sivu
    }

    private void swapToPage(GameObject page)
    {
        if (activePage != null) {
            activePage.transform.position = activePageOffScreenPosition;
        }
        activePage = page;
        activePageOffScreenPosition = activePage.transform.position;
        activePage.transform.position = new Vector3(0, 0, 0);
    }

    public void ShowHome() //näyttää Koti-sivun.
    {
        HideAllPages(); //piilotetaan ensin kaikki sivut
        if (bottomNavigationBar != null) bottomNavigationBar.SetActive(true);  //näytetään alapalkki
        homePage.SetActive(true); //laitetaan Koti-sivu näkyviin
    }

    public void Test(GameObject test)
    {

    }

    public void ShowFriends()
    {
        HideAllPages(); 
        friendsPage.SetActive(true);
    }

    public void ShowTraining()
    {
        HideAllPages();
        trainingPage.SetActive(true);
    }

    public void ShowProfile()
    {
        HideAllPages();
        profilePage.SetActive(true);
    }

    public void ShowLoginScreen()
    {
        HideAllPages();
        if (bottomNavigationBar != null) bottomNavigationBar.SetActive(false);
        loginScreenPage.SetActive(true);
    }

    public void ShowEnterLoginCredentials()
    {
        HideAllPages();
        if (bottomNavigationBar != null) bottomNavigationBar.SetActive(false);
        enterLoginCredentialsPage.SetActive(true);
    }

    public void ShowRegisterAccount()
    {
        HideAllPages();
        if (bottomNavigationBar != null) bottomNavigationBar.SetActive(false);
        registerAccountPage.SetActive(true);
    }

    public void ShowQR()
    {
        HideAllPages();
        if (bottomNavigationBar != null) bottomNavigationBar.SetActive(false);  //piilotetaan alapalkki
        qrPage.SetActive(true);
    }

    public void ShowNews()
    {
        HideAllPages();
        newsPage.SetActive(true);
    }

    public void ShowFriendProfile()
    {
        HideAllPages();
        friendProfilePage.SetActive(true);
    }

    public void ShowWorkoutDetail() //näyttää yksittäisen treenin tarkemman sivun.
    {
        HideAllPages();
        workoutDetailPage.SetActive(true);
    }

    public void ShowVisitHistory() //näyttää käyntihistoriasivun.
    {
        HideAllPages();
        visitHistoryPage.SetActive(true);
    }

    public void ShowPayments()
    {
        HideAllPages();
        paymentsPage.SetActive(true);
    }

    public void GoHome() //vie aina etusivulle
    {
        ShowHome();
    }

    public void GoBack()
    {
        ShowHome();
    }


//POP UP sivut

    public void ShowQRCodeInstructionsPopup()
    {
        HideAllPopups();
        overlay.SetActive(true);
        QRCodeInstructionsPopup.SetActive(true);
    }

    public void ShowAddFriendPopup()
    {
        HideAllPopups();
        overlay.SetActive(true);
        addFriendPopup.SetActive(true);
    }

    public void ShowAddWorkoutPopup()
    {
        HideAllPopups();
        overlay.SetActive(true);
        addWorkoutPopup.SetActive(true);
    }

    public void ShowEditWorkoutPopup()
    {
        HideAllPopups();
        overlay.SetActive(true);
        editWorkoutPopup.SetActive(true);
    }

    public void ShowAddExercisePopup()
    {
        HideAllPopups();
        overlay.SetActive(true);
        addExercisePopup.SetActive(true);
    }

    public void ShowEditExercisePopup()
    {
        HideAllPopups();
        overlay.SetActive(true);
        editExercisePopup.SetActive(true);
    }

    public void HideAllPopups()
    {
        if (overlay != null) overlay.SetActive(false);
        if (QRCodeInstructionsPopup != null) QRCodeInstructionsPopup.SetActive(false);
        if (addFriendPopup != null) addFriendPopup.SetActive(false);
        if (addWorkoutPopup != null) addWorkoutPopup.SetActive(false);
        if (editWorkoutPopup != null) editWorkoutPopup.SetActive(false);
        if (addExercisePopup != null) addExercisePopup.SetActive(false);
        if (editExercisePopup != null) editExercisePopup.SetActive(false);
    }

    private void HideAllPages()
    {
        homePage.SetActive(false);
        friendsPage.SetActive(false);
        trainingPage.SetActive(false);
        profilePage.SetActive(false);
        loginScreenPage.SetActive(false);
        enterLoginCredentialsPage.SetActive(false);
        qrPage.SetActive(false);
        newsPage.SetActive(false); 
        friendProfilePage.SetActive(false);
        workoutDetailPage.SetActive(false);
        visitHistoryPage.SetActive(false);
        paymentsPage.SetActive(false);
        registerAccountPage.SetActive(false);
    }
}