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

        public static void Initialize()
            => press = new List<ButtonPress>();

        public static void FireEvent(ButtonType type)
        {
            for (int i = 0; i < press.Count; i++)
                press[i](type);
        }

        public static void SubscribeToEvent(ButtonPress p)
            => press.Add(p);

        public static void UnsubscribeFromEvent(ButtonPress p)
            => press.Remove(p);
    }
}
