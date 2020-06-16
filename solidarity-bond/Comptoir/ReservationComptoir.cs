using System;

namespace solidarity_bond
{
    class ReservationComptoir
    {
        private CAM cam = new CAM();

        public STR_MSG Get_reservations(STR_MSG str_msg)
        {
            return cam.Dispatch(str_msg);
        }
        public STR_MSG Get_reservations_by_user(STR_MSG str_msg)
        {
            return cam.Dispatch(str_msg);
        }
        public STR_MSG Add_reservation(STR_MSG str_msg)
        {
            return cam.Dispatch(str_msg);
        }
        public STR_MSG Update_reservation(STR_MSG str_msg)
        {
            return cam.Dispatch(str_msg);
        }
    }
}
