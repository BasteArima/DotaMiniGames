public class LobbyMenu : BaseMenu
{
    public void OnBackButton()
    {
        InterfaceManager.Toggle(MenuName.MainMenu);
        SteamLobby.LeaveLobby();
    }

    public void OnClientButton()
    {
        InterfaceManager.Toggle(MenuName.ChoiseGameMenu);
    }
}
