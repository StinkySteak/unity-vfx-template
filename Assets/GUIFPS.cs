using TMPro;
using UnityEngine;

namespace StinkySteak
{
    public class GUIFPS : MonoBehaviour
    {
        [SerializeField] private float _updateTextInterval = 0.1f;
        [SerializeField] private TMP_Text _textFPS;

        private const int BUFFER_SIZE = 50;
        private float[] _deltaTimes = new float[BUFFER_SIZE];
        private int _indexer;


        private void LateUpdate()
        {
            StoreFPS();
            UpdateText();
        }

        private void StoreFPS()
        {
            if (_indexer >= BUFFER_SIZE)
                _indexer = 0;

            _deltaTimes[_indexer++] = Time.deltaTime;
        }

        private void UpdateText()
        {
            _textFPS.SetText("{0}", GetFPS());
        }

        private float GetFPS()
        {
            float fps = 0;

            foreach (float deltaTime in _deltaTimes)
                fps += deltaTime;

            fps = BUFFER_SIZE / fps;

            return fps;
        }
    }
}