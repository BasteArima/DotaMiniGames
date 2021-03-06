using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class ChooseGameSystem : BaseMonoSystem
{
    public static ChooseGameSystem Instance;
    public MatchData matchData => data.matchData;

    private BaseGameSystem[] _gameSystems;

    public override void Init(AppData data)
    {
        base.Init(data);
        if (Instance != null) Destroy(Instance.gameObject);
        Instance = this;
        SetObservables();
    }

    private void SetObservables()
    {
        data.matchData.state
            .Where(x => x == MatchData.State.MainMenu)
            .Subscribe(_ => FindGameSystems());

        data.matchData.state
            .Where(x => x == MatchData.State.EndGame)
            .Subscribe(_ => EndGame());
    }

    private void FindGameSystems()
    {
        _gameSystems = FindObjectsOfType<BaseGameSystem>();
    }

    public static void ChooseGame(MatchData.MiniGames gameType)
    {
        Instance.matchData.game.Value = gameType;

        var game = Instance._gameSystems.SingleOrDefault(m => m.GameType == Instance.matchData.game.Value);
        if (game == null) return;
        game.Initialize();
    }

    public static void RestartGame()
    {
        var game = Instance._gameSystems.SingleOrDefault(m => m.GameType == Instance.matchData.game.Value);
        if (game == null) return;
        game.RestartGame();
    }

    public static void EndGame()
    {
        Instance.matchData.game.Value = MatchData.MiniGames.None;
    }
}
