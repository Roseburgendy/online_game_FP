using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public static class Loader {

    public enum Scene {
        TitleScene,
        MainMenuScene,
        GameScene,
        LoadingScene,
        LobbyScene,
        //CharacterSelectScene,
        LXXCharacterSelectScene
    }

    private static Scene targetScene;

    // 普通加载（用于跳转到LoadingScene）
    public static void Load(Scene targetScene) {
        Loader.targetScene = targetScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    // 联机加载（Photon同步场景）
    public static void LoadNetwork(Scene targetScene) {
        PhotonNetwork.LoadLevel(targetScene.ToString());
    }

    // 在 LoadingScene 中调用，用于加载目标场景
    public static void LoaderCallback() {
        SceneManager.LoadScene(targetScene.ToString());
    }
}