using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using SlimDX;
using SlimDX.DirectInput;

namespace Lab3
{
    class Joystick
    {
        private SlimDX.DirectInput.Joystick joystick;
        private JoystickState               joyState = new JoystickState();

        public Joystick()
        {
            var di = new DirectInput();

            // Get the first device
            try
            {
                var device = di.GetDevices()[0];
                joystick = new SlimDX.DirectInput.Joystick(di, device.InstanceGuid);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("No devices: {0}", e.Message);
                Environment.Exit(1);
            }
            catch (DirectInputException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

            foreach (DeviceObjectInstance deviceObject in joystick.GetObjects())
            {
                if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                    joystick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-1000, 1000);
            }

            joystick.Acquire();
        }

        public void Poll(Action<JoystickState> f)
        {
            if (joystick.Acquire().IsFailure)
                return;

            if (joystick.Poll().IsFailure)
                return;

            joyState = joystick.GetCurrentState();
            if (Result.Last.IsFailure)
                return;

            // Joystick is all good, call the function
            f(joyState);
        }
    }
}
