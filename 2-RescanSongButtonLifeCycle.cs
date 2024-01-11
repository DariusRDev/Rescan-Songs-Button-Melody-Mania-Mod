using UnityEngine;
using UniInject;
using UnityEngine.UIElements;
using UniRx;
using System;
using System.Collections.Generic;

// Open the mod folder with Visual Studio Code and installed C# Dev Kit for IDE features such as
// code completion, error markers, parameter hints, go to definition, etc.
// ---
// Mods must implement subtypes of special mod interfaces.
// Available interfaces can be found by executing 'mod.interfaces' in the game's console.
public class RescanSongButtonLifeCycle : IOnLoadMod, IOnDisableMod
{
    // Get common objects from the app environment via Inject attribute.
    [Inject]
    private AudioManager audioManager;

    public void OnLoadMod()
    {
        // You can do anything here, for example ...

        // ... change audio clips
        // audioManager.defaultButtonSound = AudioManager.LoadAudioClipFromUriImmediately($"{modContext.ModFolder}/sounds/cartoon-jump-6462.mp3");

        Debug.Log($"{nameof(RescanSongButtonLifeCycle)}.OnLoadMod");
    }

    public void OnDisableMod()
    {
        Debug.Log($"{nameof(RescanSongButtonLifeCycle)}.OnDisableMod");
    }
}
