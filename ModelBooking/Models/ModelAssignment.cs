namespace ModelBookingWPF.Models
{
    public class ModelAssignment
    {

        public ModelAssignment()
        {
            // Ikke implementeret - Skal bruges til Json 
        }

        private Model _model;
        private Assignment _assignment;

        public Model Model
        {
            get => _model;
            set { _model = value; }
        }

        public Assignment Assignment
        {
            get => _assignment;
            set { _assignment = value; }
        }
    }
}