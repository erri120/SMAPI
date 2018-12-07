#if !SMAPI_3_0_STRICT
using System;
using StardewModdingAPI.Framework;
using StardewModdingAPI.Framework.Events;

namespace StardewModdingAPI.Events
{
    /// <summary>Events raised when the in-game date or time changes.</summary>
    [Obsolete("Use " + nameof(Mod.Helper) + "." + nameof(IModHelper.Events) + " instead. See https://smapi.io/3.0 for more info.")]
    public static class TimeEvents
    {
        /*********
        ** Properties
        *********/
        /// <summary>The core event manager.</summary>
        private static EventManager EventManager;

        /// <summary>Manages deprecation warnings.</summary>
        private static DeprecationManager DeprecationManager;


        /*********
        ** Events
        *********/
        /// <summary>Raised after the game begins a new day, including when loading a save.</summary>
        public static event EventHandler AfterDayStarted
        {
            add
            {
                TimeEvents.DeprecationManager.WarnForOldEvents();
                TimeEvents.EventManager.Legacy_AfterDayStarted.Add(value);
            }
            remove => TimeEvents.EventManager.Legacy_AfterDayStarted.Remove(value);
        }

        /// <summary>Raised after the in-game clock changes.</summary>
        public static event EventHandler<EventArgsIntChanged> TimeOfDayChanged
        {
            add
            {
                TimeEvents.DeprecationManager.WarnForOldEvents();
                TimeEvents.EventManager.Legacy_TimeOfDayChanged.Add(value);
            }
            remove => TimeEvents.EventManager.Legacy_TimeOfDayChanged.Remove(value);
        }


        /*********
        ** Public methods
        *********/
        /// <summary>Initialise the events.</summary>
        /// <param name="eventManager">The core event manager.</param>
        /// <param name="deprecationManager">Manages deprecation warnings.</param>
        internal static void Init(EventManager eventManager, DeprecationManager deprecationManager)
        {
            TimeEvents.EventManager = eventManager;
            TimeEvents.DeprecationManager = deprecationManager;
        }
    }
}
#endif
