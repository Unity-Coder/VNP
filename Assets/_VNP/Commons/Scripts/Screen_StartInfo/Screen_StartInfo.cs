using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VNP.Commons
{
    /// <summary>
    /// Utilisable pour créer un écran d'information au lancement du jeu.
    /// </summary>
    public class Screen_StartInfo : MonoBehaviour
    {
        /// <summary>
        /// Temps d'attente en seconde pour charger la scène suivante.
        /// </summary>
        [SerializeField]
        private float _waitScreen = 2f;

        /// <summary>
        /// Détermine si passe à la scène suivante sur une action clavier ou souris.
        /// </summary>
        [SerializeField]
        private bool _skipOnInputEvent = true;

        /// <summary>
        /// Nom de la scène à charger après le temps d'attente.
        /// </summary>
        [SerializeField]
        private string _scene_Start = "";

        /// <summary>
        /// Start du composant.
        /// </summary>
        private void Start()
        {
            StartCoroutine(Wait(_waitScreen));
        }

        private void Update()
        {
            if (Input.anyKey || Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                StopCoroutine(Wait(0));
                StartCoroutine(LoadScene());
            }
        }

        /// <summary>
        /// Routine d'attente avant passage à la scène _scene_Start.
        /// </summary>
        /// <param name="time">Temps d'attente en secondes.</param>
        /// <returns></returns>
        private IEnumerator Wait(float time)
        {
            // Attend time secondes.
            yield return new WaitForSeconds(time);

            // Charge la prochaine scène.
            StartCoroutine(LoadScene());
        }

        /// <summary>
        /// Charge la prochaine scène.
        /// </summary>
        private IEnumerator LoadScene()
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_scene_Start);
            while (!asyncLoad.isDone)
                yield return null;
        }
    }
}
