using System;
using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public event Action BeforeSceneUnload;
    public event Action AfterSceneLoad;


    public CanvasGroup faderCanvasGroup;
    public float fadeDuration = 1f;
    public string startingSceneName = "SecurityRoom";
    public string initialStartingPositionName = "DoorToMarket";
    public SaveData playerSaveData;


    private IEnumerator Start ()
    {
        faderCanvasGroup.alpha = 1f;

        playerSaveData.Save (PlayerMovement.startingPositionKey, initialStartingPositionName);

        yield break;
    }


    public void FadeAndLoadScene (SceneReaction sceneReaction)
    {
        
    }
}
