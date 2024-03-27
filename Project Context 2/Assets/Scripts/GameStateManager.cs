using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    static public int gameState { get; private set; } = 0;
    public NotificationScriptableObject[] newPapersState0;
    public NotificationScriptableObject[] newPapersState1;
    public NotificationScriptableObject[] newPapersState2;
    public NotificationScriptableObject[] newPapersState3;

    static public void ChangeGameState(int state)
    {
        Debug.Log(state);
        gameState = state;
        NotificationScriptableObjectManager.ClearNotificationList();

    }
    private void Awake()
    {
        EventManager.OnSceneSwitch += UpdateGameState;
        UpdateGameState();
    }
    private void UpdateGameState()
    {
        string currentscene = SceneManager.GetActiveScene().name;
        if (currentscene == "Test - Erik")
        {
            switch (gameState)
            {
                case 0:
                    NotificationScriptableObjectManager.AddNotification(newPapersState0[0]);
                    NotificationScriptableObjectManager.AddNotification(newPapersState0[1]);
                    NotificationScriptableObjectManager.AddNotification(newPapersState0[2]);
                    NotificationScriptableObjectManager.AddNotification(newPapersState0[3]);
                    break;

                case 1:
                    NotificationScriptableObjectManager.AddNotification(newPapersState1[0]);
                    NotificationScriptableObjectManager.AddNotification(newPapersState1[1]);
                    NotificationScriptableObjectManager.AddNotification(newPapersState1[2]);
                    NotificationScriptableObjectManager.AddNotification(newPapersState1[3]);
                    break;

                case 2:
                    NotificationScriptableObjectManager.AddNotification(newPapersState2[0]);
                    NotificationScriptableObjectManager.AddNotification(newPapersState2[1]);
                    NotificationScriptableObjectManager.AddNotification(newPapersState2[2]);
                    NotificationScriptableObjectManager.AddNotification(newPapersState2[3]);
                    break;

                case 3:
                    NotificationScriptableObjectManager.AddNotification(newPapersState3[0]);
                    NotificationScriptableObjectManager.AddNotification(newPapersState3[1]);
                    NotificationScriptableObjectManager.AddNotification(newPapersState3[2]);
                    break;
            }
        }
    }

}
