using System;

namespace solidarity_bond
{
    class StockComptoir
    {
        private CAM cam = new CAM();

        public STR_MSG Get_stock(STR_MSG str_msg)
        {
            return cam.Dispatch(str_msg);
        }
        public STR_MSG Update_stock(STR_MSG str_msg)
        {
            return cam.Dispatch(str_msg);
        }
    }
}
