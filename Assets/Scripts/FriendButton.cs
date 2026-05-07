using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FriendButton : MonoBehaviour
{
    public GameObject nameText;
    public GameObject statusIcon;
    public Sprite absentSprite;

    //Prepares the friend profile page according to which friend's button was pressed
    public void LoadFriendPage(GameObject friendPage)
    {
        //Get the FriendProfilePage script from the page, so we can set the contents of elements 
        FriendProfilePage friendProfilePage = friendPage.GetComponent<FriendProfilePage>();

        //Set the displayed friend name to the same as the name on the button
        friendProfilePage.nameText.GetComponent<TMP_Text>().text = nameText.GetComponent<TMP_Text>().text;

        //Set the displayed gym status sprite (v or x) to the same as on the button
        friendProfilePage.statusButtonIcon.GetComponent<Image>().sprite = statusIcon.GetComponent<Image>().sprite;

        //Set the status text based on which one the status sprite was
        if (statusIcon.GetComponent<Image>().sprite == absentSprite)
        {
            friendProfilePage.statusButtonText.GetComponent<TMP_Text>().text = "Ei ole salilla";
        }
        else
        {
            friendProfilePage.statusButtonText.GetComponent<TMP_Text>().text = "On salilla";
        }

        //Mark down which friend button was pressed so we can delete it using the delete friend button
        transform.parent.gameObject.GetComponent<FriendButtonList>().activeFriendButton = gameObject;
    }
}
