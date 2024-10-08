﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string name, Action OnLoaded = null) => _coroutineRunner.StartCoroutine(LoadScene(name, OnLoaded));

        private IEnumerator LoadScene(string nextScene, Action OnLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                OnLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
                yield return null;

            OnLoaded?.Invoke();
        }
    }
}