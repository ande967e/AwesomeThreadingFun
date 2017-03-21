using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeThreadingFun
{
    static class ButtonEventHandler
    {
        private static List<ButtonPress> press;
        private static List<AdvancedButtonPress> advPress;

        public static void Initialize()
        {
            press = new List<ButtonPress>();
            advPress = new List<AdvancedButtonPress>();
        }

        public static void FireEvent(ButtonType type)
        {
            for (int i = 0; i < press.Count; i++)
                press[i](type);
        }

        public static void FireEvent(ButtonType type, GameObject Sender)
        {
            for (int i = 0; i < advPress.Count; i++)
                advPress[i](type, Sender);

            for (int i = 0; i < press.Count; i++)
                press[i](type);
        }

        public static void SubscribeToEvent(ButtonPress p)
            => press.Add(p);

        public static void SubscribeToEvent(AdvancedButtonPress p)
            => advPress.Add(p);

        public static void UnsubscribeFromEvent(ButtonPress p)
            => press.Remove(p);

        public static void UnsubscribeFromEvent(AdvancedButtonPress p)
            => advPress.Remove(p);
    }
}
