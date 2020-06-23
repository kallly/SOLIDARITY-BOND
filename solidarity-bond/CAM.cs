using System;

namespace solidarity_bond
{
    class CAM
    {
        private ConnectionExecutionEngine connectionExecEngine;
        private StockExecutionEngine stockExecEngine;
        private ReservationExecutionEngine reservationExecEngine;
        private CentreExecutionEngine centreExecEngine;

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
                case "solidarity_app_fablab":
                    str_msg = Solidarity(str_msg);
                    break;
                case "solidarity_app_web":
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
                    case "get_stock":
                        stockExecEngine = new StockExecutionEngine();
                        str_msg = stockExecEngine.Get_stock(str_msg);
                        break;
                    case "update_stock":
                        stockExecEngine = new StockExecutionEngine();
                        str_msg = stockExecEngine.Update_stock(str_msg);
                        break;
                    case "get_reservations":
                        reservationExecEngine = new ReservationExecutionEngine();
                        str_msg = reservationExecEngine.Get_reservations(str_msg);
                        break;
                    case "get_reservations_by_user":
                        reservationExecEngine = new ReservationExecutionEngine();
                        str_msg = reservationExecEngine.Get_reservations_by_user(str_msg);
                        break;
                    case "add_reservation":
                        reservationExecEngine = new ReservationExecutionEngine();
                        str_msg = reservationExecEngine.Add_reservation(str_msg);
                        break;
                    case "update_reservation":
                        reservationExecEngine = new ReservationExecutionEngine();
                        str_msg = reservationExecEngine.Update_reservation(str_msg);
                        break;

                    case "get_centre":
                        centreExecEngine = new CentreExecutionEngine();
                        str_msg = centreExecEngine.Get_centre(str_msg);
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
