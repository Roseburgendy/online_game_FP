using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class CharacterSelectUI : MonoBehaviour {


    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button readyButton;
    [SerializeField] private TextMeshProUGUI lobbyNameText;
    [SerializeField] private TextMeshProUGUI lobbyCodeText;


    private void Awake() {
        mainMenuButton.onClick.AddListener(() => {
            KitchenGameLobby.Instance.LeaveLobby();
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.MainMenuScene);
        });
        readyButton.onClick.AddListener(() => {
            CharacterSelectReady.Instance.SetPlayerReady();
        });
    }

    private void Start() {
        Lobby lobby = KitchenGameLobby.Instance.GetLobby();

       // lobbyNameText.text = "Lobby Name: " + lobby.Name;
       // lobbyCodeText.text = "Lobby Code: " + lobby.LobbyCode;
        lobbyNameText.text = "Lobby Name: " + PhotonNetwork.CurrentRoom.Name;
    }
}