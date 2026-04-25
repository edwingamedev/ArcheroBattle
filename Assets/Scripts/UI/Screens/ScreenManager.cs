using System.Collections.Generic;
using System;

namespace EdwinGameDev.UI.Screens
{
    public static class ScreenManager
    {
        private static ScreenBehaviour _currentScreen;

        private static readonly List<ScreenBehaviour> ScreenBehaviours = new();
        private static readonly Stack<Type> LoadedScreens = new();

        public static void AssignScreen(ScreenBehaviour screenBehaviour)
        {
            if (ScreenBehaviours.Contains(screenBehaviour))
            {
                return;
            }

            ScreenBehaviours.Add(screenBehaviour);
            screenBehaviour.OnDeactivate();
        }

        public static void UnassignScreen(ScreenBehaviour screenBehaviour)
        {
            if (!ScreenBehaviours.Contains(screenBehaviour))
            {
                return;
            }

            ScreenBehaviours.Remove(screenBehaviour);
        }

        public static void ReloadPreviousScreen()
        {
            LoadScreen(LoadedScreens.Peek());
        }

        public static void LoadScreen(Type screenType)
        {
            ScreenBehaviour screen = GetScreenByType(screenType);

            if (!screen)
            {
                return;
            }
            
            if (_currentScreen != null &&
                _currentScreen.GetType() != screenType &&
                _currentScreen.GetType() != typeof(GameOverScreen))
            {
                LoadedScreens.Push(_currentScreen.GetType());
            }

            Load(screen);
        }

        private static void Load(ScreenBehaviour screen)
        {
            // Disable previous screen
            _currentScreen?.OnDeactivate();

            // Sets new screen
            _currentScreen = screen;

            // Enable new screen
            _currentScreen?.OnActivate();
        }

        private static ScreenBehaviour GetScreenByType(Type screenType)
        {
            return ScreenBehaviours.Find((screen) => screen.GetType() == screenType);
        }
    }
}