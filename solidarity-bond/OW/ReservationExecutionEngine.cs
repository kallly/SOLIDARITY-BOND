using System;

namespace solidarity_bond
{
    class ReservationExecutionEngine
    {
        private ReservationComponent reservationComponent;
        public ReservationExecutionEngine()
        {
            reservationComponent = new ReservationComponent();
        }
        public STR_MSG Get_reservations(STR_MSG str_msg)
        {
            return reservationComponent.Get_reservations(str_msg);;
        }
        public STR_MSG Get_reservations_by_user(STR_MSG str_msg)
        {
            return reservationComponent.Get_reservations_by_user(str_msg);;
        }
        public STR_MSG Add_reservation(STR_MSG str_msg)
        {
            return reservationComponent.Add_reservation(str_msg);;
        }
        public STR_MSG Update_reservation(STR_MSG str_msg)
        {
            return reservationComponent.Update_reservation(str_msg);;
        }
    }
}
