using System.Collections.Generic;
using UnityEngine;

public class FriendButtonList : MonoBehaviour
{
    public List<GameObject> friendButtons = new List<GameObject>();
    private const float BUTTON_SPACING = 3;
    public GameObject activeFriendButton;

    public void removeActiveFriendButton()
    {
        friendButtons.Remove(activeFriendButton);
        Destroy(activeFriendButton);
        alignButtons();
    }

    private void alignButtons()
    {
        for (int i = 0; i < friendButtons.Count; i++)
        {
            friendButtons[i].transform.position = transform.position - new Vector3(0, i * BUTTON_SPACING, 0);
        }
    }
}
