using System;
using System.Collections.Generic;
using UniInject;
using UnityEngine;
using UnityEngine.UIElements;

// Mod interface to do something when a scene is loaded.
// Available scenes are found in the EScene enum.
public class RescanSongButtonSceneMod : ISceneMod
{
    // Get common objects from the app environment via Inject attribute.
    [Inject]
    private UIDocument uiDocument;

    [Inject]
    private SceneNavigator sceneNavigator;




    private readonly List<IDisposable> disposables = new List<IDisposable>();

    public void OnSceneEntered(SceneEnteredContext sceneEnteredContext)
    {
        if (sceneEnteredContext.Scene == EScene.SongSelectScene)
        {
            GameObject gameObject = new GameObject();

            gameObject.name = nameof(RescanSongButtonMonoBehaviour);
            RescanSongButtonMonoBehaviour behaviour = gameObject.AddComponent<RescanSongButtonMonoBehaviour>();
            sceneEnteredContext.SceneInjector.Inject(behaviour);
        }
    }
}

public class RescanSongButtonMonoBehaviour : MonoBehaviour, INeedInjection
{

    [Inject(UxmlName = R.UxmlNames.sceneTitle)]
    private VisualElement songIndexContainer;


    [Inject]
    private SongMetaManager songMetaManager;

    // Start is called once before Update
    private void Start()
    {
        VisualElement rescanButton = new Button();
        // rescanButton.AddToClassList("mt-2");
        rescanButton.AddToClassList("transparentButton");
        rescanButton.AddToClassList("p-0");

        // add click handler
        rescanButton.RegisterCallback<MouseUpEvent>(ev =>
        {
            songMetaManager.ReloadSongMetas();
        });

        // add text
        rescanButton.Add(new Label("↺"));

        songIndexContainer.GetParent().Add(rescanButton);
    }




}
