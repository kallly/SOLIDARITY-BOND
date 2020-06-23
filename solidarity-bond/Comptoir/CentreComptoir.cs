namespace solidarity_bond
{
    public class CentreComptoir
    {
        private CAM cam = new CAM();

        public STR_MSG Get_centre(STR_MSG str_msg)
        {
            return cam.Dispatch(str_msg);
        }
    }
}