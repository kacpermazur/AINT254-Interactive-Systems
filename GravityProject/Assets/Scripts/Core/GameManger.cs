using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class GameManger : MonoBehaviour, IInitializable
    {
        private static readonly string GameMangerObjectName = typeof(GameManger).Name;
        private static GameManger _instance;
        
        public enum GameState
        {
            MENU,
            GAME,
            PAUSE
        }

        private GameState _currentGameState;
        
        public void UpdateGameState(GameState type){ _currentGameState = type; }
        public GameState GetCurrentGameState() { return _currentGameState; }

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            
            Initialize();
            
            DontDestroyOnLoad(this);
        }

        public void Initialize()
        {
            // Testing
            _currentGameState = GameState.GAME;
        }
        
        

    }
}