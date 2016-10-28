using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames.BasicApi.SavedGame;
using System;

namespace Pertinate.GooglePlay
{
    public class GooglePlaySingleton : MonoBehaviour
    {
        public static GooglePlaySingleton singleton = null;
        public bool signedIn()
        {
            if (!signInOverride)
            {
                return Social.localUser.authenticated;
            }
            else
            {
                return true;
            }
        }
        public bool signInOverride = false;
        public bool nearbyInitialized = false;

        private void Awake()
        {
            if(singleton && singleton != this)
            {
                DestroyImmediate(gameObject);
                return;
            }
            else
            {
                singleton = this;
                DontDestroyOnLoad(gameObject);
            }
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if(arg0.buildIndex == 1)
            {

            }
        }

        private void Start()
        {
            if (!Social.localUser.authenticated)
            {
                PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
                    .EnableSavedGames()
                    .Build();
                PlayGamesPlatform.InitializeInstance(config);
                //PlayGamesPlatform.DebugLogEnabled = true;
                PlayGamesPlatform.Activate();
                Social.localUser.Authenticate((bool success) =>
                {
                    if (success)
                    {
                        PlayGamesPlatform.InitializeNearby((client) =>
                        {
                            nearbyInitialized = true;
                        });
                        if (SceneManager.GetActiveScene().buildIndex == 0)
                        {
                            SceneManager.LoadScene(1);
                        }
                    }
                    else
                    {
                        nearbyInitialized = false;
                        signInOverride = true;
                        if (SceneManager.GetActiveScene().buildIndex == 0)
                        {
                            SceneManager.LoadScene(1);
                        }
                        //TODO: warn user they are not logged in
                    }
                });
            }
        }
    }
}
