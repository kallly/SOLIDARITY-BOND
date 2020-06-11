using System;

namespace solidarity_bond
{
    class ConnectionComptoir
    {
        private CAM cam = new CAM();

        public STR_MSG Connection(STR_MSG str_msg)
        {
            return cam.Dispatch(str_msg);
        }
    }
}
