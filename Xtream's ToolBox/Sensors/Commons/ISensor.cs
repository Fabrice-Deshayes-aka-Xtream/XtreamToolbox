using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Xtream_ToolBox {
    interface ISensor {

        // init UI
        void initUI();

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        void initSensorData();

        // refresh UI based on sensor Data
        void refreshUI();

        // call when toolbox location is update
        void updateLocation();

        // return extended panel if exist (null otherwise)
        Form getExtendedPanel();
    }
}
