using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[CreateAssetMenu(menuName = "Data/MatchData")]
public class MatchData : ScriptableObject
{
    public enum State
    {
        None,
        AppStart,
        MainMenu,
        Lobby,
        InitializeGame,
        Game,
        EndGame,
        Finish,
    }

    public enum MiniGames
    {
        None,
        HiddenPool,
        RunoMess,
        TeaEyeWinner,
        ShockContent,
        MemeHistory,
        MenuQuiz,
        CodeHero
    }

    public ReactiveProperty<State> state = new ReactiveProperty<State>(State.None);
    public ReactiveProperty<MiniGames> game = new ReactiveProperty<MiniGames>(MiniGames.None);
}
