using System;

namespace solidarity_bond
{
    class CAM
    {
        private ConnectionExecutionEngine connectionExecEngine;
        public CAM()
        {
        }

        public STR_MSG Dispatch(STR_MSG str_msg)
        {
            // Call mapping entity
            switch (str_msg.application)
            {
                case "solidarity_app_console":
                    str_msg = Solidarity(str_msg);
                    break;
                default:
                    str_msg.data["success"] = string.Empty;
                    str_msg.data["error"] = "Unknown application";
                    break;
            }

            return str_msg;
        }

        private STR_MSG Solidarity(STR_MSG str_msg)
        {

            if(str_msg.version == "1.0")
            {
                switch (str_msg.data["operation"])
                {
                    case "connection":
                        connectionExecEngine = new ConnectionExecutionEngine();
                        str_msg = connectionExecEngine.Connection(str_msg);
                        break;
                default:
                        str_msg.data["success"] = string.Empty;
                        // unknown or not alloed op
                        str_msg.data["error"] = str_msg.data["operation"] + " operation is not allowed for" + str_msg.application + "application.";
                        break;
                }
            }

            return str_msg;
        }
    }
}
