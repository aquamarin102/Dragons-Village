using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Scripts.World
{
    public class WinLoseManager : IDisposable
    {
        private List<TrapsLoseView> _trapsLoseViews;
        private List<WinFlagView> _winFlagsViews;

        public WinLoseManager(List<TrapsLoseView> trapsLoseViews,List<WinFlagView> winFlagsViews)
        {
            _trapsLoseViews = trapsLoseViews;
            _winFlagsViews = winFlagsViews;

            foreach (var winFlagView in winFlagsViews)
            {
                winFlagView.OnLevelObjectContact += OnLevelObjectContactWin;
            }
            
            foreach (var trapLoseView in trapsLoseViews)
            {
                trapLoseView.OnLevelObjectContact += OnLevelObjectContactLose;
            }
        }

        private void OnLevelObjectContactWin(WinFlagView contactView)
        {
            if (_winFlagsViews.Contains(contactView))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        private void OnLevelObjectContactLose(TrapsLoseView contactView)
        {
            if (_trapsLoseViews.Contains(contactView))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        public void Dispose()
        {
            foreach (var winFlagView in _winFlagsViews)
                winFlagView.OnLevelObjectContact -= OnLevelObjectContactWin;
            
            foreach (var trapsLoseView in _trapsLoseViews)
                trapsLoseView.OnLevelObjectContact -= OnLevelObjectContactLose;
        }
    }
}