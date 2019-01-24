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
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_scene_Start);
            while (!asyncLoad.isDone)
                yield return null;
        }
    }
}
