using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FriendButton : MonoBehaviour
{
    public GameObject nameText;
    public GameObject statusIcon;
    public Sprite absentSprite;

    public void LoadFriendPage(GameObject friendPage)
    {
        FriendProfilePage profilePage = friendPage.GetComponent<FriendProfilePage>();
        profilePage.nameText.GetComponent<TMP_Text>().text = nameText.GetComponent<TMP_Text>().text;
        profilePage.statusButtonIcon.GetComponent<Image>().sprite = statusIcon.GetComponent<Image>().sprite;

        if (statusIcon.GetComponent<Image>().sprite == absentSprite)
        {
            profilePage.statusButtonText.GetComponent<TMP_Text>().text = "Ei ole salilla";
        }
        else
        {
            profilePage.statusButtonText.GetComponent<TMP_Text>().text = "On salilla";
        }

        transform.parent.gameObject.GetComponent<FriendButtonList>().activeFriendButton = gameObject;
    }
}
