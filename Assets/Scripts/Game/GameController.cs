using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private float _sceneChangeDelay;

        private void Awake()
        {
            //максимальное значение кадров в секунду
            Application.targetFrameRate = 60;
        }

        //вызывается по ивенту смерти игрока
        [UsedImplicitly]
        public void OnPlayerDied() 
        {
            StartCoroutine(ShowGameOver());
        }

        //задержка, чтобы успели проиграться анимация и звук смерти игрока.
        private IEnumerator ShowGameOver()
        {
            yield return new WaitForSeconds(_sceneChangeDelay); 
            SceneManager.LoadSceneAsync(GlobalConstants.GAME_OVER_SCENE);
        }
    }
}