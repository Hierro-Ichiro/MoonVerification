﻿using Moon.Asyncs;
using UnityEngine;

namespace MiniGames.Common
{
    public class GameScenarioExecutor: MonoBehaviour
    {
        public GameProgress progress;
        public GameScenarioBase scenario;
        public string nextSceneName;

        private void Awake()
        {
            if (scenario == null)
            {
                Debug.LogError("GameScenarioExecutor has no scenario", this);
                return;
            }

            scenario.Inject(progress);

            Planner.Chain()
                    .AddFunc(scenario.ExecuteScenario)
                    .AddAction(LoadNextScene)
                ;
        }

        private void LoadNextScene()
        {
            // TODO: fade in
            // loading scene
            // TODO: fade out
        }
    }
}
