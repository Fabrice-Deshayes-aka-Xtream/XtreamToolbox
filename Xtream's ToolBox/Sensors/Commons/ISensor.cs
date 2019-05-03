using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace XtreamToolbox
{
    interface ISensor
    {

        // init UI
        void InitUI();

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        void InitSensorData();

        // refresh UI based on sensor Data
        void RefreshUI();

        // call when toolbox location is update
        void UpdateLocation();

        // return extended panel if exist (null otherwise)
        Form GetExtendedPanel();
    }
}
